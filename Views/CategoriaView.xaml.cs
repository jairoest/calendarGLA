namespace PocketOne.Views;

public partial class CategoriaView : ContentPage
{
	public CategoriaView()
	{
        BindingContext = App.Current.Services.GetRequiredService<CategoriaViewModel>();
        InitializeComponent();
	}

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }

}