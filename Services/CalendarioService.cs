
namespace CalendarAE.Services
{
    internal class CalendarioService : ICalendario
    {
        private readonly SQLLiteHelper<Calendario> db;

        public CalendarioService()
        => db = new();

        public Task<int> Delete(Calendario calendario)
        => Task.FromResult(db.Delete(calendario));

        public Task<List<Calendario>> GetAll()
        => Task.FromResult(db.GetAll());

        public Task<Calendario> GetById(int id)
        => Task.FromResult(db.Get(id));

        public Task<int> Insert(Calendario calendario)
        => Task.FromResult(db.Insert(calendario));

        public Task<int> Update(Calendario calendario)
        => Task.FromResult(db.Update(calendario));

        public int LlenarCalendarioBase()
        {
            Calendario calendario1 = new()
            {
                Fecha = new DateTime(2024, 1, 31),
                Dia = 1,
                Tipo = 2,
                Observaciones = "nuevo registro"
            };
            Insert(calendario1);

            return 0;

        }
    }
}
