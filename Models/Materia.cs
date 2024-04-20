using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarAE.Models
{
    public class Materia : BaseModel
    {
        public string NombreMateria { get; set; }

        public string NombreCurso { get; set; }

        public string Color { get; set; }


        public Materia NuevaMateria(string _nombremateria, string _nombrecurso, string _color)
        {
            Materia materia = new()
            {
                NombreMateria = _nombremateria,
                NombreCurso = _nombrecurso,
                Color = _color
            };
            return materia;
        }
    }
}
