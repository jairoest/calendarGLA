using PocketOne.Interfaces;
using PocketOne.Services;

namespace PocketOne;

public partial class App : Application
{
    public static new App Current => (App)Application.Current;

    public IServiceProvider Services { get; }

    public App()
    {
        var services = new ServiceCollection();
        Services = ConfigureServices(services);

        InitializeComponent();

        Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjU4ODIyMUAzMjMyMmUzMDJlMzBXTVNiRUJITjVJS2c3NGI4L2t1UklXY0FrZlJNdUNNeGFyZ3NSNzRJeDk0PQ ==; MjU4ODIyMkAzMjMyMmUzMDJlMzBib0w5ZExOalBsb2kvVVIxZmtFTHF1Yk1TY1o0NlhUTnNadjloRFNzWlQwPQ ==");

        MainPage = new AppShell();
    }

    public static IServiceProvider ConfigureServices(ServiceCollection services)
    {
        // Services
        services.AddSingleton<IPeriodo, PeriodoService>();
        services.AddSingleton<ICategoria, CategoriaService>();
        services.AddSingleton<ISubCategoria, SubCategoriaService>();
        services.AddSingleton<IMovimiento, MovimientoService>();
        services.AddSingleton<IDialogService, DialogService>();

        // ViewModels
        services.AddTransient<PeriodosViewModel>();
        services.AddTransient<PeriodoViewModel>();

        services.AddTransient<CategoriasViewModel>();
        services.AddTransient<CategoriaViewModel>();

        services.AddTransient<SubCategoriasViewModel>();
        services.AddTransient<SubCategoriaViewModel>();

        services.AddTransient<MovimientosViewModel>();
        services.AddTransient<MovimientoViewModel>();


        // Views
        services.AddSingleton<ListaPeriodos>();
        services.AddSingleton<PeriodoView>();
        services.AddSingleton<PeriodoCardView>();

        services.AddSingleton<ListaCategorias>();
        services.AddSingleton<CategoriaView>();

        services.AddSingleton<ListaSubCategorias>();
        services.AddSingleton<SubCategoriaView>();

        services.AddSingleton<ListaMovimientos>();
        services.AddSingleton<MovimientoView>();

        return services.BuildServiceProvider();
    }
}
