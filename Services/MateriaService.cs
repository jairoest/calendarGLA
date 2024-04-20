
namespace CalendarAE.Services
{
    internal class MateriaService : IMateria
    {
        private readonly SQLLiteHelper<Materia> db;

        public MateriaService()
        => db = new();

        public Task<int> Delete(Materia materia)
        => Task.FromResult(db.Delete(materia));

        public Task<List<Materia>> GetAll()
        => Task.FromResult(db.GetAll());

        public Task<Materia> GetById(int id)
        => Task.FromResult(db.Get(id));

        public Task<int> Insert(Materia materia)
        => Task.FromResult(db.Insert(materia));

        public Task<int> Update(Materia materia)
        => Task.FromResult(db.Update(materia));

        public Task<List<Materia>> GetByCurso(string curso)
        => Task.FromResult(db.connectionDB.Table<Materia>().Where(w => w.NombreCurso == curso).ToList());

        public int LlenarMateriasBase()
        {
            List<Materia> listaMaterias = new()
            {
                new Materia().NuevaMateria("Math", "4A", "#95fab9"),
                new Materia().NuevaMateria("English", "4A", "#84b6f4"),
                new Materia().NuevaMateria("Physical Education", "4A", "#b7fadf"),
                new Materia().NuevaMateria("Lenguaje", "4A", "#bc98f3"),
                new Materia().NuevaMateria("Ciencias Sociales", "4A", "#f9a59a"),
                new Materia().NuevaMateria("Science", "4A", "#f79ae5"),
                new Materia().NuevaMateria("Arts", "4A", "#f4fab4"),
                new Materia().NuevaMateria("Aprendizaje SE", "4A", "#e1b1bc"),
                new Materia().NuevaMateria("Computer Science", "4A", "#fa5f49"),
                new Materia().NuevaMateria("Sports", "4A", "#888a8a"),
                new Materia().NuevaMateria("Etica", "4A", "#5dc460"),
                new Materia().NuevaMateria("Tutoría", "4A", "#d1eaf9"),
                new Materia().NuevaMateria("Acogida", "4A", "#bdbfbf"),
                new Materia().NuevaMateria("Break", "4A", "#bdbfbf"),
                new Materia().NuevaMateria("Despedida", "4A", "#bdbfbf"),
                new Materia().NuevaMateria("Lunch", "4A", "#bdbfbf")
            };

            foreach (Materia materia in listaMaterias)
            {
                Insert(materia);
            }

            return 0;

        }

    }
}
