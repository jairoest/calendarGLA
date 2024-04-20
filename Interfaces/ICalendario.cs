
using CalendarAE.Models;

namespace CalendarAE.Interfaces
{
    internal interface ICalendario
    {
        public Task<List<Calendario>> GetAll();

        public Task<Calendario> GetById(int id);

        public Task<Calendario> GetByDate(DateTime fecha);

        public Task<int> Insert(Calendario calendario);

        public Task<int> Update(Calendario calendario);

        public Task<int> Delete(Calendario calendario);

        public int LlenarCalendarioBase();

    }
}
