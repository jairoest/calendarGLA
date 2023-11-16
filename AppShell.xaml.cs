namespace PocketOne;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(ListaPeriodos), typeof(ListaPeriodos));
        Routing.RegisterRoute(nameof(PeriodoView), typeof(PeriodoView));
        Routing.RegisterRoute(nameof(PeriodoCardView), typeof(PeriodoCardView));

        Routing.RegisterRoute(nameof(ListaCategorias), typeof(ListaCategorias));
        Routing.RegisterRoute(nameof(CategoriaView), typeof(CategoriaView));

        Routing.RegisterRoute(nameof(ListaSubCategorias), typeof(ListaSubCategorias));
        Routing.RegisterRoute(nameof(SubCategoriaView), typeof(SubCategoriaView));

        Routing.RegisterRoute(nameof(ListaMovimientos), typeof(ListaMovimientos));
        Routing.RegisterRoute(nameof(MovimientoView), typeof(MovimientoView));


    }
}
