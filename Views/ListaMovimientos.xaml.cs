namespace PocketOne.Views;

public partial class ListaMovimientos : ContentPage
{
	public ListaMovimientos()
	{
        InitializeComponent();
        BindingContext = App.Current.Services.GetRequiredService<MovimientosViewModel>();
        
	}
}