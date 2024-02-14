
namespace CalendarAE.Services
{
    internal class CursoService : ICurso
    {
        private readonly SQLLiteHelper<Curso> db;

        public CursoService()
        => db = new();

        public Task<int> Delete(Curso curso)
        => Task.FromResult(db.Delete(curso));

        public Task<List<Curso>> GetAll()
        => Task.FromResult(db.GetAll());

        public Task<Curso> GetById(int id)
        => Task.FromResult(db.Get(id));

        public Task<int> Insert(Curso curso)
        => Task.FromResult(db.Insert(curso));

        public Task<int> Update(Curso curso)
        => Task.FromResult(db.Update(curso));

        public Task<List<Curso>> GetbyEstado(byte estado)
        => Task.FromResult(db.connectionDB.Table<Curso>().Where(w => w.Estado == estado).ToList());

        public int LlenarCursosBase()
        {
            List<Curso> listaCursos = new List<Curso>
            {
                new Curso().NuevoCurso("4A", 1),
                new Curso().NuevoCurso("4B", 1),
                new Curso().NuevoCurso("4C", 1),
            };

            foreach (Curso curso in listaCursos)
            {
                Insert(curso);
            }

            return 0;

        }
    }
}
