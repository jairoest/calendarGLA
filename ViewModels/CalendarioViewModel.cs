using CommunityToolkit.Mvvm.Input;
using CalendarAE.Services;
using System.Collections.ObjectModel;

namespace CalendarAE.ViewModels;

[QueryProperty(nameof(CursoDetails), nameof(CursoDetails))]
public partial class CalendarioViewModel: BaseViewModel
{
    private readonly ICalendario calendario_service;
    private readonly IHorario horario_service;
    private readonly ICurso curso_service;
    private readonly IFestivo festivo_service;

    public ObservableCollection<Calendario> ListaCalendario{ get; set; } = new();

    public ObservableCollection<Curso> ListaCursos { get; set; } = new();

    public ObservableCollection<Horario> ListaHorario { get; set; } = new();


    [ObservableProperty]
    Calendario diaSeleccionado;

    [ObservableProperty]
    Curso cursoDetails;

    [ObservableProperty]
    public byte filtroCurso;

    public CalendarioViewModel()
    {
        calendario_service = App.Current.Services.GetService<ICalendario>();
        horario_service = App.Current.Services.GetService<IHorario>();
        curso_service = App.Current.Services.GetService<ICurso>();
        festivo_service = App.Current.Services.GetService<IFestivo>();

        // _dialog = App.Current.Services.GetService<IDialogService>();
        // Task.Run(async () => await ListarMovimientos());
    }

    [RelayCommand]
    public async Task ConsultarCalendario()
    {
        IsLoading = true;
        ListaCalendario.Clear();
        var lista = await calendario_service.GetAll();

        if (ListaCalendario.Count == 0)
        {
            calendario_service.LlenarCalendarioBase();
            lista = await calendario_service.GetAll();
        }

        foreach (var item in lista) ListaCalendario.Add(item);
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


}
