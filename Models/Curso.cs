using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalendarAE.Models
{
    public class Curso : BaseModel
    {
        /// <summary>
        /// Identifica el curso, Ej. 3C
        /// </summary>
        public string NombreCurso { get; set; }

        public byte Estado { get; set; }


        public Curso NuevoCurso(string _nombrecurso, byte _estado)
        {
            Curso curso = new()
            {
                NombreCurso = _nombrecurso,
                Estado = _estado
            };
            return curso;
        }

    }
}
