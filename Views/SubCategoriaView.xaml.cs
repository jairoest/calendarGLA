namespace PocketOne.Views;

public partial class SubCategoriaView : ContentPage
{
	public SubCategoriaView()
	{
        BindingContext = App.Current.Services.GetRequiredService<SubCategoriaViewModel>();
        InitializeComponent();
	}

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }

}