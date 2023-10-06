using Syncfusion.Maui.DataGrid;
using System.Globalization;

namespace PocketOne.Services
{
    public class ColorConverter : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo info)
        {
            var limite = (value as Movimiento).FechaLimite;
            var estado = (value as Movimiento).Estado;
            var hoy = DateTime.Now;

            // Condicion para validar que el movimiento no se ha pagado y se paso la fecha
            if (!estado && hoy.CompareTo(limite) > 0)
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
