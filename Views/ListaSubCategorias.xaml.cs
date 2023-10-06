namespace PocketOne.Views;

public partial class ListaSubCategorias : ContentPage
{
	public ListaSubCategorias()
	{
        BindingContext = App.Current.Services.GetRequiredService<SubCategoriasViewModel>();
        InitializeComponent();
	}
}