using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketOne.Models
{
    public class Categoria : BaseModel
    {
        /// <summary>
        /// Nombre de la categoria Ej. Credito, Casa, Carro
        /// </summary>
        public string NombreCategoria { get; set; }

        /// <summary>
        /// El tipo indica si es ingreso o egreso, es determinado por la categoria de movimiento
        /// </summary>
        public string TipoMovimiento { get; set; }

        public Categoria Nuevo(string nombreCategoria, string tipoMovimiento) 
        {
            this.NombreCategoria = nombreCategoria;
            this.TipoMovimiento = tipoMovimiento;

            return this;
        }  

    }
}
