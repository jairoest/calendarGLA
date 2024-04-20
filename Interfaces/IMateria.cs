
using CalendarAE.Models;

namespace CalendarAE.Interfaces
{
    internal interface IMateria
    {
        public Task<List<Materia>> GetAll();

        public Task<Materia> GetById(int id);

        public Task<List<Materia>> GetByCurso(string curso);

        public Task<int> Insert(Materia materia);

        public Task<int> Update(Materia materia);

        public Task<int> Delete(Materia materia);

        public int LlenarMateriasBase();

    }
}
