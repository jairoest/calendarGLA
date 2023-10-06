namespace PocketOne.Models
{
    [Table("Periodo")]
    public class Periodo : BaseModel
    {
        /// <summary>
        /// Define el mes o periodo de movimientos
        /// </summary>
        public DateTime FechaPeriodo { get; set; }

        /// <summary>
        /// Estado del periodo para determinar si esta cerrado o en curso (Activo). Solo un periodo puede etar activo
        /// 1. Inactivo  2. Activo
        /// </summary>
        public bool ProcesoActual { get; set; }

        /// <summary>
        /// Define el estado del periodo
        /// 1. Abierto  2. Cerrado
        /// </summary>
        public bool Estado { get; set; }

        /// <summary>
        /// Contiene el total de ingresos del periodo
        /// </summary>
        public decimal TotalIngresos { get; set; }

        /// <summary>
        /// Contiene total de egresos del periodo
        /// </summary>
        public decimal TotalEgresos { get; set; }

        /// <summary>
        /// Contiene la diferencia entre Ingresos del periodo y los movimientos en estado Pagado
        /// </summary>
        public decimal Saldo { get; set; }

        /// <summary>
        /// Contiene la diferencia entre TotalIngresos - TotalEgresos
        /// </summary>
        public decimal Balance { get; set; }

        public Periodo Nuevo(DateTime fechaPeriodo) 
        {
            this.FechaPeriodo = fechaPeriodo;
            this.ProcesoActual = false;
            this.Estado = false;

            return this;
        }
    }
}