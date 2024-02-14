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
        /// Horario para materia Ej. 9.00 - 10:15 am
        /// </summary>
        public string Hora { get; set; }

        /// <summary>
        /// Nombre de la materia
        /// Ej. Sociales
        /// </summary>
        public string Materia { get; set; }

        public Horario NuevoHorario(string _nombrecurso, byte _dia, string _hora, string _materia)
        {
            Horario horario = new Horario
            {
                NombreCurso = _nombrecurso,
                Dia = _dia,
                Hora = _hora,
                Materia = _materia
            };
            return horario;
        }
    }
}
