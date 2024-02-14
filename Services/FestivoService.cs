
namespace CalendarAE.Services
{
    internal class FestivoService : IFestivo
    {
        private readonly SQLLiteHelper<Festivo> db;

        public FestivoService() 
        => db = new();

        public Task<int> Delete(Festivo festivo)
        => Task.FromResult(db.Delete(festivo));

        public Task<List<Festivo>> GetAll()
        => Task.FromResult(db.GetAll());

        public Task<Festivo> GetByFecha(DateTime fecha)
        => Task.FromResult(db.connectionDB.Table<Festivo>().Where(w => w.Fecha == fecha).FirstOrDefault());

        public Task<Festivo> GetById(int id)
        => Task.FromResult(db.Get(id));

        public Task<int> Insert(Festivo festivo)
        => Task.FromResult(db.Insert(festivo));

        public int LlenarFestivosBase()
        {
            List<Festivo> listaPeriodo = new()
            {
                new Festivo().NuevoFestivo(new DateTime(2023, 03, 28), 4, "Semana Santa"),
                new Festivo().NuevoFestivo(new DateTime(2023, 03, 29), 4, "Semana Santa"),
                new Festivo().NuevoFestivo(new DateTime(2023, 03, 30), 4, "Semana Santa")
            };

            foreach (Festivo festivo in listaPeriodo)
            {
                Insert(festivo);
            }

            return 0;
        }

        public Task<int> Update(Festivo festivo)
        => Task.FromResult(db.Update(festivo));
    }
}
