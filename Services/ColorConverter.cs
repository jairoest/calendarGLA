using Syncfusion.Maui.DataGrid;
using System.Globalization;

namespace CalendarAE.Services
{
    public class ColorConverter : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo info)
        {
            var limite = (value as Calendario).Fecha;
            var estado = (value as Calendario).Tipo;
            var hoy = DateTime.Now;

            // Condicion para validar que el movimiento no se ha pagado y se paso la fecha
            if (estado >= 0 && hoy.CompareTo(limite) > 0)
                return Colors.DarkSalmon;
            else
                return Colors.White;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
