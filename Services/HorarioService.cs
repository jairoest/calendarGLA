
using CalendarAE.Interfaces;

namespace CalendarAE.Services
{
    internal class HorarioService : IHorario
    {
        private readonly SQLLiteHelper<Horario> db;

        public HorarioService()
        => db = new();

        public Task<int> Delete(Horario horario)
        => Task.FromResult(db.Delete(horario));

        public Task<List<Horario>> GetAll()
        => Task.FromResult(db.GetAll());

        public Task<Horario> GetById(int id)
        => Task.FromResult(db.Get(id));

        public Task<List<Horario>> GetByCursoDia(string curso, byte dia)
        => Task.FromResult(db.connectionDB.Table<Horario>().Where(w => w.NombreCurso == curso && w.Dia == dia).ToList());

        public Task<int> Insert(Horario horario)
        => Task.FromResult(db.Insert(horario));

        public Task<int> Update(Horario horario)
        => Task.FromResult(db.Update(horario));

        public int LlenarHorarioBase()
        {
            Horario horario = new()
            {
                Id = 1,
                NombreCurso = "4A",
                Dia = 1,
                Materia = "Science",
                Hora = "7:30 - 8:15 a.m."

            };
            Insert(horario);

            return 0;
        }
    }
}
