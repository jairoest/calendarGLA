using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalendarAE.Models
{
    public class Horario : BaseModel
    {
       
        /// <summary>
        /// Identifica el curso, Ej. 3C
        /// </summary>
        public string NombreCurso { get; set; }

        /// <summary>
        /// Identifica el dia 1-6, Ej. Dia 1
        /// </summary>
        public byte Dia { get; set; }

        /// <summary>
        /// Hora de inicio para materia Ej. 9.00 - 10:15 am
        /// </summary>
        public DateTime HoraInicio { get; set; }

        /// <summary>
        /// Hora final para materia Ej. 9.00 - 10:15 am
        /// </summary>
        public DateTime HoraFin { get; set; }

        /// <summary>
        /// Nombre de la materia
        /// Ej. Sociales
        /// </summary>
        public string Materia { get; set; }

        /// <summary>
        /// Indica si el evento es todo el dia. Para representacion en el scheduler
        /// </summary>
        public bool EsTodoElDia { get; set; }

        /// <summary>
        /// Metodo para crear un nuevo evento en el horario de clases
        /// </summary>
        /// <param name="_nombrecurso"></param>
        /// <param name="_dia"></param>
        /// <param name="_horainicio"></param>
        /// <param name="_horafin"></param>
        /// <param name="_materia"></param>
        /// <param name="_estodoeldia"></param>
        /// <returns></returns>
        public Horario NuevoHorario(string _nombrecurso, byte _dia, DateTime _horainicio, DateTime _horafin, string _materia, bool _estodoeldia)
        {
            Horario horario = new()
            {
                NombreCurso = _nombrecurso,
                Dia = _dia,
                HoraInicio = _horainicio,
                HoraFin = _horafin,
                Materia = _materia,
                EsTodoElDia = _estodoeldia
            };
            return horario;
        }
    }
}
