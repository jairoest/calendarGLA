using CalendarAE.Interfaces;
using CalendarAE.Services;

namespace CalendarAE;

public partial class App : Application
{
    public static new App Current => (App)Application.Current;

    public IServiceProvider Services { get; }

    public App()
    {
        var services = new ServiceCollection();
        Services = ConfigureServices(services);

        InitializeComponent();

        // License 24.2.5
        Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzA2ODc1MEAzMjM0MmUzMDJlMzBCNXpQSU9Bbm9PQUVma1hia3FOVXRncWxjZ01KMmI0ZkUwNEkzVDZmOHA4PQ ==; MzA2ODc1MUAzMjM0MmUzMDJlMzBBVktIUEpscUZOV3ZYZC9ReXQ3a0tMbEFQUk5TUnhJOWtBOHFNclpSQndnPQ ==");

        MainPage = new AppShell();
    }

    public static IServiceProvider ConfigureServices(ServiceCollection services)
    {
        // Services
        services.AddSingleton<ICalendario, CalendarioService>();
        services.AddSingleton<IFestivo, FestivoService>();
        services.AddSingleton<IHorario, HorarioService>();
        services.AddSingleton<ICurso, CursoService>();
        services.AddSingleton<IMateria, MateriaService>();
        services.AddSingleton<IDialogService, DialogService>();

        // ViewModels
        services.AddTransient<CalendarioViewModel>();
        services.AddTransient<HorarioViewModel>();

        // Views
        services.AddSingleton<CalendarioView>();
        services.AddSingleton<HorarioView>();
        services.AddSingleton<FestivosView>();

        return services.BuildServiceProvider();
    }
}
