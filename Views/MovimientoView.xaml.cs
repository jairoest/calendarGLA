namespace PocketOne.Views;

public partial class MovimientoView : ContentPage
{
	public MovimientoView()
	{
        BindingContext = App.Current.Services.GetRequiredService<MovimientoViewModel>();
        InitializeComponent();
	}

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }

}