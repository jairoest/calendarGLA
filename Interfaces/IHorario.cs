
using CalendarAE.Models;

namespace CalendarAE.Interfaces
{
    public interface IHorario
    {
        public Task<List<Horario>> GetAll();

        public Task<Horario> GetById(int id);

        public Task<List<Horario>> GetByCursoDia(string curso, byte dia);

        public Task<int> Insert(Horario horario);
        
        public Task<int> Update(Horario horario);
        
        public Task<int> Delete(Horario horario);

        public int LlenarHorarioBase();

    }
}
