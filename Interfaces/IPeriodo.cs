
namespace PocketOne.Interfaces
{
    public interface IPeriodo
    {
        public Task<List<Periodo>> GetAll();

        public Task<Periodo> GetById(int id);

        public Task<Periodo> GetByEstado(bool estado);

        public Task<Periodo> GetByFecha(DateTime fecha);

        public Task<int> Insert(Periodo periodo);
        
        public Task<int> Update(Periodo periodo);
        
        public Task<int> Delete(Periodo periodo);

        public int LlenarPeriodosBase();

    }
}
