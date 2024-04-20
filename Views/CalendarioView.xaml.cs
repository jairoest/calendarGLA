using Syncfusion.Maui.Calendar;
using System.Runtime.CompilerServices;

namespace CalendarAE.Views;

public partial class CalendarioView : ContentPage
{
    public CalendarioViewModel _calendarioviewmodel;

    
    public CalendarioView()
	{
        InitializeComponent();
        BindingContext = App.Current.Services.GetRequiredService<CalendarioViewModel>();
        _calendarioviewmodel = App.Current.Services.GetRequiredService<CalendarioViewModel>();

        calendar.MonthView.SpecialDayPredicate = (date) =>
        {
            if (_calendarioviewmodel.ListaFestivos.Contains(date.Date) || date.DayOfWeek == System.DayOfWeek.Saturday || date.DayOfWeek == System.DayOfWeek.Sunday)
            {
                return new CalendarIconDetails() { Fill = Brush.Transparent};
            }

            if (_calendarioviewmodel.ListaEventos.Contains(date.Date))
            {
                return new CalendarIconDetails() { Icon = CalendarIcon.Dot };
            }

            return null;
        };
        
    }

    private void calendar_SelectionChanged(object sender, CalendarSelectionChangedEventArgs e)
    {
        DateTime diaseleccionado = (DateTime) e.NewValue;
        Task task = _calendarioviewmodel.ConsultarDiaSeleccionado(diaseleccionado);

        
    }
}