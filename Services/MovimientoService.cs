
namespace PocketOne.Services
{
    internal class MovimientoService : IMovimiento
    {
        private readonly SQLLiteHelper<Movimiento> db;


        public MovimientoService()
        => db = new();

        public Task<int> Delete(Movimiento movimiento)
        => Task.FromResult(db.Delete(movimiento));

        public Task<List<Movimiento>> GetAll()
        => Task.FromResult(db.GetAll());

        public Task<Movimiento> GetById(int id)
        => Task.FromResult(db.Get(id));

        public Task<int> Insert(Movimiento movimiento)
        => Task.FromResult(db.Insert(movimiento));

        public Task<int> Update(Movimiento movimiento)
        => Task.FromResult(db.Update(movimiento));

        public Task<List<Movimiento>> GetbyPeriodo(DateTime fechaPeriodo)
        => Task.FromResult(db.connectionDB.Table<Movimiento>().Where(w => w.FechaPeriodo == fechaPeriodo).ToList());

        public int LlenarMovimientosBase()
        {
            List<Movimiento> listaMovimientos = new List<Movimiento>
            {
                new Movimiento().Nuevo(new System.DateTime(2023, 06, 30), "Nomina", "Ingreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 06, 30), "TC Scotia", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 06, 30), "Credito 1 Consumo Scotia", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 06, 30), "Credito 2 Libranza Scotia", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 06, 30), "Uni Andes", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 06, 30), "Gimandes", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 06, 30), "Servicios ETB", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 06, 30), "Servicios Codensa", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 06, 30), "Servicios EAAB", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 06, 30), "ETB Jairo", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 06, 30), "Mercado Alkosto", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 06, 30), "TC Itau", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 06, 30), "Credito AV Villas", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 06, 30), "Credito AV Villas2 Predial", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 06, 30), "Carro Gasolina", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 06, 30), "Mercado Naranjas", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 06, 30), "Comida Hatchiko", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 06, 30), "Comida", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),

                new Movimiento().Nuevo(new System.DateTime(2023, 07, 31), "Nomina", "Ingreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 07, 31), "TC Scotia", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 07, 31), "Credito 1 Consumo Scotia", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 07, 31), "Credito 2 Libranza Scotia", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 07, 31), "Uni Andes", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 07, 31), "Gimandes", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 07, 31), "Servicios ETB", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 07, 31), "Servicios Codensa", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 07, 31), "Servicios EAAB", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 07, 31), "ETB Jairo", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 07, 31), "Mercado Alkosto", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 07, 31), "TC Itau", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 07, 31), "Credito AV Villas", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 07, 31), "Credito AV Villas2 Predial", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 07, 31), "Carro Gasolina", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 07, 31), "Mercado Naranjas", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 07, 31), "Comida Hatchiko", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 07, 31), "Comida", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),

                new Movimiento().Nuevo(new System.DateTime(2023, 08, 31), "Nomina", "Ingreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 08, 31), "TC Scotia", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 08, 31), "Credito 1 Consumo Scotia", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 08, 31), "Credito 2 Libranza Scotia", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 08, 31), "Uni Andes", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 08, 31), "Gimandes", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 08, 31), "Servicios ETB", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 08, 31), "Servicios Codensa", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 08, 31), "Servicios EAAB", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 08, 31), "ETB Jairo", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 08, 31), "Mercado Alkosto", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 08, 31), "TC Itau", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 08, 31), "Credito AV Villas", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 08, 31), "Credito AV Villas2 Predial", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 08, 31), "Carro Gasolina", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 08, 31), "Mercado Naranjas", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 08, 31), "Comida Hatchiko", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 08, 31), "Comida", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true)

            };

            foreach (Movimiento movimiento in listaMovimientos)
            {
                Insert(movimiento);
            }

            return 0;

        }
    }
}
