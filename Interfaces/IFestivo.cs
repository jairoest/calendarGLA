
using CalendarAE.Models;

namespace CalendarAE.Interfaces
{
    internal interface IFestivo
    {
        public Task<List<Festivo>> GetAll();

        public Task<Festivo> GetByFecha(DateTime fecha);

        public Task<List<Festivo>> GetByTipo(int tipo);

        public Task<int> Insert(Festivo festivo);

        public Task<int> Update(Festivo festivo);

        public Task<int> Delete(Festivo festivo);

        public int LlenarFestivosBase();

    }
}
