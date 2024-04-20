using CommunityToolkit.Mvvm.Input;
using CalendarAE.Services;
using System.Collections.ObjectModel;

namespace CalendarAE.ViewModels;

[QueryProperty(nameof(DiaSeleccionado), nameof(DiaSeleccionado))]
public partial class HorarioViewModel: BaseViewModel
{
    private readonly ICalendario calendario_service;
    private readonly IHorario horario_service;
    private readonly ICurso curso_service;
    private readonly IFestivo festivo_service;
    private readonly IMateria materia_service;

    private readonly IDialogService dialog_service;


    public ObservableCollection<Calendario> ListaCalendario{ get; set; } = new();

    public ObservableCollection<Curso> ListaCursos { get; set; } = new();

    public ObservableCollection<HorarioCal> ListaHorario { get; set; } = new();

    public ObservableCollection<DateTime> ListaFestivos { get; set; } = new();

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
    public DateTime displayDate;

    [ObservableProperty]
    public string observaciones;

    public HorarioViewModel()
    {
        calendario_service = App.Current.Services.GetService<ICalendario>();
        horario_service = App.Current.Services.GetService<IHorario>();
        curso_service = App.Current.Services.GetService<ICurso>();
        festivo_service = App.Current.Services.GetService<IFestivo>();
        materia_service = App.Current.Services.GetService<IMateria>();
        materia_service = App.Current.Services.GetService<IMateria>();
        dialog_service = App.Current.Services.GetService<IDialogService>();

        Task tarea = ConsultarFestivos();

        // _dialog = App.Current.Services.GetService<IDialogService>();
        // Task.Run(async () => await ListarMovimientos());

    }

    [RelayCommand]
    public async Task ConsultarCalendario()
    {
        IsLoading = true;
        ListaCalendario.Clear();
        var lista = await calendario_service.GetAll();

        foreach (var item in lista) await calendario_service.Delete(item);
        
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

    public async Task ConsultarFestivos()
    {
        IsLoading = true;
        ListaFestivos.Clear();
        var lista = await festivo_service.GetAll();

        if (lista.Count == 0)
        {
            festivo_service.LlenarFestivosBase();
            lista = await festivo_service.GetAll();
        }

        foreach (var item in lista) ListaFestivos.Add(item.Fecha);
        IsLoading = false;
        IsRefreshing = false;
    }


    [RelayCommand]
    public async Task ListarCursosEstado()
    {
        IsLoading = true;
        ListaCursos.Clear();

        var listaBase = await curso_service.GetAll();
        foreach (var item in listaBase) await curso_service.Delete(item);  // Borra todos los movimientos 
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
        IsLoading = true;
        ListaHorario.Clear();

        DisplayDate = DateTime.Now;

        // Borrar horario para inicializar datos
        var listaBase = await horario_service.GetAll();
        
        /*
        foreach (var item in listaBase)
        {
            await horario_service.Delete(item);  // Borra todos items del horario
        }
        listaBase = await horario_service.GetAll();
        */

        if (listaBase.Count == 0)
        {
            await horario_service.LlenarHorarioBase();
        }

        List<Materia> listamaterias = await materia_service.GetByCurso(Preferences.Default.Get("CursoActual", "4A"));

        /*
        foreach (var item in listamaterias)
        {
            await materia_service.Delete(item);  // Borra todos items del horario
        }
        listamaterias = await materia_service.GetByCurso("4A");
        */

        if (listamaterias.Count == 0)
        {
            materia_service.LlenarMateriasBase();
            listamaterias = await materia_service.GetByCurso(Preferences.Default.Get("CursoActual", "4A"));
        }

        List<Horario> lista = await horario_service.GetByCurso(Preferences.Default.Get("CursoActual", "4A"));  // Leer el horario del curso activo
        foreach (var item in lista)
        {
            // Arreglar tema color de fondo
            // Ver configuracion de parametros
            // Agregar Observaciones en dias de clase
            HorarioCal itemhorario = new()
            {
                NombreCurso = item.NombreCurso,
                Dia = item.Dia,
                HoraInicio = item.HoraInicio,
                HoraFin = item.HoraFin,
                Materia = item.Materia,
                EsTodoElDia = item.EsTodoElDia,
                ColorFondo = item.EsTodoElDia ? Brush.GhostWhite : (Brush)new BrushTypeConverter().ConvertFromString(listamaterias.Find(e => e.NombreMateria == item.Materia).Color)
            };
            ListaHorario.Add(itemhorario);
        }

        // Titulo = $"Curso {CursoDetails.NombreCurso}";
        IsLoading = false;
        IsRefreshing = false;
    }


    [RelayCommand]
    public async Task ListarHorarioCurso()
    {
        IsLoading = true;
        ListaHorario.Clear();

        var lista = await horario_service.GetByCursoDia(CursoDetails.NombreCurso, DiaSeleccionado.Dia);
        // foreach (var item in lista) ListaHorario.Add(item);

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
                Observaciones = "Diario";
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
