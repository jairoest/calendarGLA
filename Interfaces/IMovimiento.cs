
namespace PocketOne.Interfaces
{
    internal interface IMovimiento
    {
        public Task<List<Movimiento>> GetAll();

        public Task<List<Movimiento>> GetbyPeriodo(DateTime fechaPeriodo);

        public Task<Movimiento> GetById(int id);

        public Task<int> Insert(Movimiento movimiento);

        public Task<int> Update(Movimiento movimiento);

        public Task<int> Delete(Movimiento movimiento);

        public int LlenarMovimientosBase();

    }
}
