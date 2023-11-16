
namespace PocketOne.Services
{
    internal class PeriodoService : IPeriodo
    {
        private readonly SQLLiteHelper<Periodo> db;

        public PeriodoService() 
        => db = new();

        public Task<int> Delete(Periodo periodo)
        => Task.FromResult(db.Delete(periodo));

        public Task<List<Periodo>> GetAll()
        => Task.FromResult(db.GetAll());

        public Task<Periodo> GetByEstado(bool actual)
        => Task.FromResult(db.connectionDB.Table<Periodo>().Where(w => w.ProcesoActual == actual).FirstOrDefault());

        public Task<Periodo> GetByFecha(DateTime fecha)
        => Task.FromResult(db.connectionDB.Table<Periodo>().Where(w => w.FechaPeriodo == fecha).FirstOrDefault());

        public Task<Periodo> GetById(int id)
        => Task.FromResult(db.Get(id));

        public Task<int> Insert(Periodo periodo)
        => Task.FromResult(db.Insert(periodo));

        public int LlenarPeriodosBase()
        {
            List<Periodo> listaPeriodo = new()
            {
                new Periodo().Nuevo(new DateTime(2023, 06, 30), false),
                new Periodo().Nuevo(new DateTime(2023, 07, 31), false),
                new Periodo().Nuevo(new DateTime(2023, 08, 31), true)
            };

            foreach (Periodo periodo in listaPeriodo)
            {
                Insert(periodo);
            }

            return 0;
        }

        public Task<int> Update(Periodo periodo)
        => Task.FromResult(db.Update(periodo));
    }
}
