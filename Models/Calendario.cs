using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalendarAE.Models
{
    public class Calendario : BaseModel
    {

        public DateTime Fecha { get; set; }
        
        /// <summary>
        /// Define el nro de dia en el calendario escolar 0,..., 6
        /// </summary>
        public byte Dia { get; set; }
        
        /// <summary>
        /// Define el tipo de dia
        /// 0. Festivo reinicia Dia, 1. Habil, 2. Festivo, 3. Evento, 4. Vacaciones
        /// </summary>
        public int Tipo { get; set; }
        
        /// <summary>
        /// Observaciones para indicar cosas como a que festivo corresponde una fecha en particular
        /// </summary>
        public string Observaciones { get; set; }

    }
}
