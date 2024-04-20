using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarAE.Models
{
    public class HorarioCal : Horario
    {
        /// <summary>
        /// Permite establecer el color a usar en el calendario, segun la materia
        /// </summary>
        public Brush ColorFondo { get; set; }

        public HorarioCal() 
        { 
        
        }


    }
}
