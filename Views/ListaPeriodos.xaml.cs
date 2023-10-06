namespace PocketOne.Views;

public partial class ListaPeriodos : ContentPage
{
	public PeriodosViewModel _periodosviewmodel;
    public ListaPeriodos()
	{
		BindingContext = App.Current.Services.GetRequiredService<PeriodosViewModel>();
		_periodosviewmodel = App.Current.Services.GetRequiredService<PeriodosViewModel>();
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
		{
			_periodosviewmodel.ListarPeriodosCommand.Execute(null);
		}
    }
}