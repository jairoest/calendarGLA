namespace PocketOne.Views;

public partial class PeriodoView : ContentPage
{
	public PeriodoView()
	{
        InitializeComponent(); 
		BindingContext = App.Current.Services.GetRequiredService<PeriodoViewModel>();
		
	}

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }
}