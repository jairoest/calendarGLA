namespace CalendarAE;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(CalendarioView), typeof(CalendarioView));
        Routing.RegisterRoute(nameof(HorarioView), typeof(HorarioView));
        Routing.RegisterRoute(nameof(FestivosView), typeof(FestivosView));

    }
}
