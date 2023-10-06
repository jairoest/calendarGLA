
namespace PocketOne.Models
{
    public class SubCategoria : BaseModel
    {
        /// <summary>
        /// Identificador unico para la subcategoria
        /// </summary>
        public int IdCategoria { get; set; }

        /// <summary>
        /// Nombre de la Subcategoria Ej. Gasolina, Credito
        /// </summary>
        public string NombreSubCategoria { get; set; }

        public SubCategoria Nuevo(int idCategoria, string nombreSubCategoria) 
        {
            this.IdCategoria = idCategoria;
            this.NombreSubCategoria = nombreSubCategoria;

            return this;
        }

    }
}
