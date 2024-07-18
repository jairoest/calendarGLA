using CommunityToolkit.Mvvm.Input;
using CalendarAE.Services;
using System.Collections.ObjectModel;

namespace CalendarAE.ViewModels;

[QueryProperty(nameof(DiaSeleccionado), nameof(DiaSeleccionado))]
public partial class CalendarioViewModel: BaseViewModel
{
    private readonly ICalendario calendario_service;
    private readonly IHorario horario_service;
    private readonly ICurso curso_service;
    private readonly IFestivo festivo_service;
    private readonly IMateria materia_service;

    public ObservableCollection<Calendario> ListaCalendario{ get; set; } = new();

    public ObservableCollection<Curso> ListaCursos { get; set; } = new();

    public ObservableCollection<Horario> ListaHorario { get; set; } = new();

    public ObservableCollection<DateTime> ListaFestivos { get; set; } = new();

    public ObservableCollection<DateTime> ListaEventos { get; set; } = new();


    [ObservableProperty]
    Calendario diaSeleccionado;

    [ObservableProperty]
    Curso cursoDetails;

    [ObservableProperty]
    public byte filtroCurso;

    [ObservableProperty]
    public string fechaSeleccionada;

    [ObservableProperty]
    public string dia;

    [ObservableProperty]
    public string observaciones;

    public CalendarioViewModel()
    {
        calendario_service = App.Current.Services.GetService<ICalendario>();
        horario_service = App.Current.Services.GetService<IHorario>();
        curso_service = App.Current.Services.GetService<ICurso>();
        festivo_service = App.Current.Services.GetService<IFestivo>();
        materia_service = App.Current.Services.GetService<IMateria>();

        Task tarea = ConsultarFestivos();

    }

    [RelayCommand]
    public async Task ConsultarCalendario()
    {
        IsLoading = true;

        // Iniciar datos base de las tablas 
        bool iniciardatos = Preferences.Default.Get("IniciarDatos", true);
        if (iniciardatos)
        {
            await IniciarDatosBase();
            Preferences.Default.Set("IniciarDatos", false);
        }

        ListaCalendario.Clear();
        var lista = await calendario_service.GetAll();

        if (lista.Count == 0)
        {
            calendario_service.LlenarCalendarioBase();
            lista = await calendario_service.GetAll();
        }

        foreach (var item in lista) ListaCalendario.Add(item);

        // Al inicio de la app, muestra el dia actual por defecto. 
        // Se puede mostrar el siguiente dia habil
        await ConsultarDiaSeleccionado(DateTime.Today);

        IsLoading = false;
        IsRefreshing = false;
    }

    [RelayCommand]
    public async Task IniciarDatosBase()
    {
        IsLoading = true;

        // TODO: Permitir seleccion del curso actual
        Preferences.Default.Set("CursoActual", "4A");

        // Permitir configuracion de parametros
        Preferences.Default.Set("FechaInicioPeriodo", new DateTime(2024, 01, 26, 0, 0, 0));
        Preferences.Default.Set("FechaFinPeriodo", new DateTime(2024, 12, 06, 0, 0, 0));


        #region 1. Iniciar datos de cursos
        var listacursos = await curso_service.GetAll();
        foreach (var item in listacursos) await curso_service.Delete(item);  // Borra todos items del horario
        curso_service.LlenarCursosBase();
        #endregion

        #region 2. Iniciar datos de materias
        var listamaterias = await materia_service.GetAll();
        foreach (var item in listamaterias) await materia_service.Delete(item);  // Borra todos items del horario
        materia_service.LlenarMateriasBase();
        #endregion

        #region 3. Iniciar datos de dias Festivos
        var listafestivos = await festivo_service.GetAll();
        foreach (var item in listafestivos) await festivo_service.Delete(item);
        festivo_service.LlenarFestivosBase();
        #endregion

        #region 4. Iniciar datos calendario
        var listacalendario = await calendario_service.GetAll();
        foreach (var item in listacalendario) await calendario_service.Delete(item);
        calendario_service.LlenarCalendarioBase();
        #endregion

        #region 5. Iniciar datos de Horario
        var listahorario = await horario_service.GetAll();
        foreach (var item in listahorario) await horario_service.Delete(item);  // Borra todos items del horario
        await horario_service.LlenarHorarioBase();
        #endregion

        IsLoading = false;
        IsRefreshing = false;
    }


    public async Task ConsultarFestivos()
    {
        IsLoading = true;

        ListaFestivos.Clear();
        var lista = await festivo_service.GetAll();

        foreach (var item in lista)
        {
            if (item.Tipo != 0) ListaFestivos.Add(item.Fecha);
            else ListaEventos.Add(item.Fecha);
        }

        IsLoading = false;
        IsRefreshing = false;
    }

    [RelayCommand]
    public async Task ListarCursosEstado()
    {
        IsLoading = true;
        ListaCursos.Clear();

        var listaBase = await curso_service.GetAll();
        // foreach (var item in listaBase) await movimiento_service.Delete(item);  // Borra todos los movimientos 
        if (listaBase.Count == 0)
        {
            curso_service.LlenarCursosBase();
        }
        var lista = await curso_service.GetbyEstado(1);  // Cursos en estado 1, Activo
        
        foreach (var item in lista) ListaCursos.Add(item);

        Titulo = $"Curso {CursoDetails.NombreCurso}";

        IsLoading = false;
        IsRefreshing = false;
    }

    [RelayCommand]
    public async Task ConsultarHorario()
    {
        var navparam = new Dictionary<string, object>
        {
            { "DiaSeleccionado", DiaSeleccionado }
        };

        await Shell.Current.GoToAsync(nameof(HorarioView), navparam);
    }

    [RelayCommand]
    public async Task ListarHorarioCurso()
    {
        IsLoading = true;
        ListaHorario.Clear();

        var lista = await horario_service.GetByCursoDia(CursoDetails.NombreCurso, DiaSeleccionado.Dia);
        foreach (var item in lista) ListaHorario.Add(item);

        Titulo = $"Horario de {CursoDetails.NombreCurso}";

        IsLoading = false;
        IsRefreshing = false;
    }

    [RelayCommand]
    public async Task ConsultarDiaSeleccionado(DateTime fecha)
    {
        IsLoading = true;

        DiaSeleccionado = await calendario_service.GetByDate(fecha);

        FechaSeleccionada = DiaSeleccionado.Fecha.ToLongDateString();

        switch (DiaSeleccionado.Tipo)
        {
            case 0:
                // Dia normal con clase
                Dia = $"Día {DiaSeleccionado.Dia}";
                Observaciones = DiaSeleccionado.Observaciones;
                break;

            case 1: // Evento colegio presencial sin clase
            case 2: // Festivo normal
            case 3: // Sin clase. Evento colegio
                Dia = " ";
                Observaciones = DiaSeleccionado.Observaciones;
                break;

            case 4:
                // Vacaciones
                Dia = " ";
                Observaciones = DiaSeleccionado.Observaciones;
                break;

            default:
                break;
        }

        IsLoading = false;
        IsRefreshing = false;

    }

}
