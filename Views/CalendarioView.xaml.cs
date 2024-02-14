namespace CalendarAE.Views;

public partial class CalendarioView : ContentPage
{
	public CalendarioView()
	{
        InitializeComponent();
        BindingContext = App.Current.Services.GetRequiredService<CalendarioViewModel>();
        
	}
}