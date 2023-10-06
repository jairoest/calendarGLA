namespace PocketOne.Views;

public partial class ListaCategorias : ContentPage
{
	public ListaCategorias()
	{
        BindingContext = App.Current.Services.GetRequiredService<CategoriasViewModel>();
        InitializeComponent();
	}
}