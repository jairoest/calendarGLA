namespace PocketOne.Views.Templates;

public partial class ItemPeriodo : ContentView
{
	private readonly PeriodosViewModel periodosViewModel;
	public ItemPeriodo()
	{
        BindingContext = App.Current.Services.GetRequiredService<PeriodosViewModel>();
		periodosViewModel = App.Current.Services.GetRequiredService<PeriodosViewModel>();

        InitializeComponent();
	}
}