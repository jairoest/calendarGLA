using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalendarAE.Models
{
    public class Festivo : BaseModel
    {
        public DateTime Fecha { get; set; }
        /// <summary>
        /// Define el tipo de dia festivo
        /// 0. Festivo y reinicia Dia a 1, 2. Festivo normal, 3. Evento, 4. Vacaciones
        /// </summary>
        public int Tipo { get; set; }

        /// <summary>
        /// Permite describir el dia festivo. Evento hace referencia a un evento del colegio, como entrega de notas, y durante ese dia no hay clase
        /// </summary>
        public string Descripcion { get; set; }

        public Festivo NuevoFestivo(DateTime _fecha, int _tipo, string _descripcion)
        {
            Festivo festivo = new Festivo();
            festivo.Fecha = _fecha;
            festivo.Tipo = _tipo;
            festivo.Descripcion = _descripcion;
            return festivo;
        }
    }
}
