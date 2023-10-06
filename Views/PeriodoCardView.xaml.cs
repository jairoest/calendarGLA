namespace PocketOne.Views;

public partial class PeriodoCardView : ContentPage
{
    public PeriodoCardView()
	{
        InitializeComponent();
        BindingContext = App.Current.Services.GetRequiredService<PeriodoViewModel>();
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }
}