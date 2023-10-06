
namespace PocketOne.Models
{
    public class Movimiento : BaseModel
    {
        /// <summary>
        /// Periodo del movimiento
        /// </summary>
        public DateTime FechaPeriodo { get; set; }

        /// <summary>
        /// Referencia a la subcategoria
        /// </summary>
        public string NomSubCategoria { get; set; }

        /// <summary>
        /// El tipo indica si es ingreso o egreso
        /// </summary>
        public string TipoMovimiento { get; set; }

        /// <summary>
        /// Valor del movimiento en $$$
        /// </summary>
        public decimal Valor { get; set; }   

        /// <summary>
        /// Indica la fecha maxima para pago
        /// </summary>
        public DateTime FechaLimite { get; set; }

        /// <summary>
        /// Indica la fecha maxima real de pago
        /// </summary>
        public DateTime FechaReal { get; set; }

        /// <summary>
        /// Indica el estado del movimiento Pagado True   Presupuestado False
        /// </summary>
        public bool Estado { get; set; }

        public Movimiento Nuevo(DateTime fechaPeriodo, string nomSubCategoria, string tipoMovimiento, decimal valor, DateTime fechaLimite, DateTime fechaReal, bool estado)
        {
            // IdMovimiento = idMovimiento;
            FechaPeriodo = fechaPeriodo;
            NomSubCategoria = nomSubCategoria;
            TipoMovimiento = tipoMovimiento;
            Valor = valor;
            FechaLimite = fechaLimite;
            FechaReal = fechaReal;
            Estado = estado;

            return this;
        }
    }
}
