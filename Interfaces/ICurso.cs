
using CalendarAE.Models;

namespace CalendarAE.Interfaces
{
    internal interface ICurso
    {
        public Task<List<Curso>> GetAll();

        public Task<List<Curso>> GetbyEstado(byte estado);

        public Task<Curso> GetById(int id);

        public Task<int> Insert(Curso curso);

        public Task<int> Update(Curso curso);

        public Task<int> Delete(Curso curso);

        public int LlenarCursosBase();

    }
}
