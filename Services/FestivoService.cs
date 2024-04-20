
namespace CalendarAE.Services
{
    internal class FestivoService : IFestivo
    {
        private readonly SQLLiteHelper<Festivo> db;

        public FestivoService() 
        => db = new();

        public Task<int> Delete(Festivo festivo)
        => Task.FromResult(db.Delete(festivo));

        public Task<List<Festivo>> GetAll()
        => Task.FromResult(db.GetAll());

        public Task<Festivo> GetByFecha(DateTime fecha)
        => Task.FromResult(db.connectionDB.Table<Festivo>().Where(w => w.Fecha == fecha).FirstOrDefault());

        public Task<List<Festivo>> GetByTipo(int tipo)
        => Task.FromResult(db.connectionDB.Table<Festivo>().Where(w => w.Tipo == tipo).ToList());

        public Task<Festivo> GetById(int id)
        => Task.FromResult(db.Get(id));

        public Task<int> Insert(Festivo festivo)
        => Task.FromResult(db.Insert(festivo));

        public int LlenarFestivosBase()
        {
            try
            {
                List<Festivo> listaFestivos = new()
                {
                    new Festivo().NuevoFestivo(new System.DateTime(2024, 03, 6), 1, "Primera Jornada de desarrollo humano"),// Jornada de desarrollo humano
                    new Festivo().NuevoFestivo(new System.DateTime(2024, 03, 8), 0, "Corte parcial Primer Trimestre"),
                    new Festivo().NuevoFestivo(new System.DateTime(2024, 03, 25), 2, "Festivo - San José"),
                    new Festivo().NuevoFestivo(new System.DateTime(2024, 03, 26), 4, "Semana Santa - Martes"),
                    new Festivo().NuevoFestivo(new System.DateTime(2024, 03, 27), 4, "Semana Santa - Miercoles"),
                    new Festivo().NuevoFestivo(new System.DateTime(2024, 03, 28), 4, "Semana Santa - Jueves"),
                    new Festivo().NuevoFestivo(new System.DateTime(2024, 03, 29), 4, "Semana Santa - Viernes"),
                    new Festivo().NuevoFestivo(new System.DateTime(2024, 04, 1), 4, "Jornada pedagógica"),
                    new Festivo().NuevoFestivo(new System.DateTime(2024, 04, 2), 0, "Regreso a clases"),
                    new Festivo().NuevoFestivo(new System.DateTime(2024, 04, 29), 0, "Finalización Primer Trimestre"),
                    new Festivo().NuevoFestivo(new System.DateTime(2024, 04, 30), 0, "Inicio Segundo Trimestre"),
                    new Festivo().NuevoFestivo(new System.DateTime(2024, 05, 1), 2, "Día del trabajo"),
                    new Festivo().NuevoFestivo(new System.DateTime(2024, 05, 10), 3, "Student Led Conference (Primer Trimestre)"),// **** Entrega de notas
                    new Festivo().NuevoFestivo(new System.DateTime(2024, 05, 13), 3, "Festivo - Ascención"),
                    new Festivo().NuevoFestivo(new System.DateTime(2024, 05, 31), 2, "Día del docente"), // Dia del profe
                    new Festivo().NuevoFestivo(new System.DateTime(2024, 06, 3), 2, "Festivo - Corpus Christi"),
                    new Festivo().NuevoFestivo(new System.DateTime(2024, 06, 10), 2, "Festivo - Sagrado Corazón"),
                    new Festivo().NuevoFestivo(new System.DateTime(2024, 06, 17), 4, "Vacaciones mitad de año"),
                    new Festivo().NuevoFestivo(new System.DateTime(2024, 06, 18), 4, "Vacaciones mitad de año"),
                    new Festivo().NuevoFestivo(new System.DateTime(2024, 06, 19), 4, "Vacaciones mitad de año"),
                    new Festivo().NuevoFestivo(new System.DateTime(2024, 06, 20), 4, "Vacaciones mitad de año"),
                    new Festivo().NuevoFestivo(new System.DateTime(2024, 06, 21), 4, "Vacaciones mitad de año"),
                    new Festivo().NuevoFestivo(new System.DateTime(2024, 06, 24), 4, "Vacaciones mitad de año"),
                    new Festivo().NuevoFestivo(new System.DateTime(2024, 06, 25), 4, "Vacaciones mitad de año"),
                    new Festivo().NuevoFestivo(new System.DateTime(2024, 06, 26), 4, "Vacaciones mitad de año"),
                    new Festivo().NuevoFestivo(new System.DateTime(2024, 06, 27), 4, "Vacaciones mitad de año"),
                    new Festivo().NuevoFestivo(new System.DateTime(2024, 06, 28), 4, "Vacaciones mitad de año"),
                    new Festivo().NuevoFestivo(new System.DateTime(2024, 07, 1), 4, "Vacaciones mitad de año"),
                    new Festivo().NuevoFestivo(new System.DateTime(2024, 07, 2), 4, "Vacaciones mitad de año"),
                    new Festivo().NuevoFestivo(new System.DateTime(2024, 07, 3), 4, "Vacaciones mitad de año"),
                    new Festivo().NuevoFestivo(new System.DateTime(2024, 07, 4), 4, "Vacaciones mitad de año"),
                    new Festivo().NuevoFestivo(new System.DateTime(2024, 07, 5), 4, "Vacaciones mitad de año"),
                    new Festivo().NuevoFestivo(new System.DateTime(2024, 07, 8), 2, "Jornada pedagógica"),// Retorno docentes despues de vacaciones
                    new Festivo().NuevoFestivo(new System.DateTime(2024, 07, 9), 0, "Regreso a clases"),
                    new Festivo().NuevoFestivo(new System.DateTime(2024, 07, 11), 0, "Corte parcial Segundo Trimestre"),
                    new Festivo().NuevoFestivo(new System.DateTime(2024, 07, 19), 1, "Segunda Jornada de Desarrollo Humano"),
                    new Festivo().NuevoFestivo(new System.DateTime(2024, 07, 20), 2, "Festivo - Dia de la Independencia"),
                    new Festivo().NuevoFestivo(new System.DateTime(2024, 08, 7), 2, "Festivo - Batalla de Boyacá"),
                    new Festivo().NuevoFestivo(new System.DateTime(2024, 08, 15), 0, "Finalización segundo trimestre"),
                    new Festivo().NuevoFestivo(new System.DateTime(2024, 08, 16), 0, "Inicio Tercer Trimestre"),
                    new Festivo().NuevoFestivo(new System.DateTime(2024, 08, 19), 2, "Festivo - La Asunción"),
                    new Festivo().NuevoFestivo(new System.DateTime(2024, 08, 23), 3, "Student Led Conference (Segundo Trimestre)"),
                    new Festivo().NuevoFestivo(new System.DateTime(2024, 09, 20), 1, "Tercera Jornada de Desarrollo Humano"),
                    new Festivo().NuevoFestivo(new System.DateTime(2024, 09, 30), 0, "Corte Parcial Segundo Trimestre"),
                    new Festivo().NuevoFestivo(new System.DateTime(2024, 10, 7), 4, "Semana de receso"),
                    new Festivo().NuevoFestivo(new System.DateTime(2024, 10, 8), 4, "Semana de receso"),
                    new Festivo().NuevoFestivo(new System.DateTime(2024, 10, 9), 4, "Semana de receso"),
                    new Festivo().NuevoFestivo(new System.DateTime(2024, 10, 10), 4, "Semana de receso"),
                    new Festivo().NuevoFestivo(new System.DateTime(2024, 10, 11), 4, "Semana de receso"),
                    new Festivo().NuevoFestivo(new System.DateTime(2024, 10, 14), 2, "Festivo - Dia de La Raza"),
                    new Festivo().NuevoFestivo(new System.DateTime(2024, 10, 15), 0, "Regreso de estudiantes a clase"),
                    new Festivo().NuevoFestivo(new System.DateTime(2024, 10, 25), 3, "Evento - Día del Estudiante"),// Dia del estudiante
                    new Festivo().NuevoFestivo(new System.DateTime(2024, 11, 4), 2, "Festivo - Dia de Todos los santos"),
                    new Festivo().NuevoFestivo(new System.DateTime(2024, 11, 8), 3, "Clausuras Ciclos Intermedio, Pre juvenil, Juvenil y Especializado"),
                    new Festivo().NuevoFestivo(new System.DateTime(2024, 11, 11), 2, "Festivo - Independencia de Cartagena"),
                    new Festivo().NuevoFestivo(new System.DateTime(2024, 11, 15), 0, "Finalización Tercer Trimestre"),
                    new Festivo().NuevoFestivo(new System.DateTime(2024, 11, 22), 3, "Student Led Conference 3º a 11º (Tercer Trimestre")
                };

                foreach (Festivo festivo in listaFestivos)
                {
                    Insert(festivo);
                }

                return 0;
            }
            catch (Exception ex)
            {
                string mensaje = ex.Message;
                return 0;
            }
        }

        public Task<int> Update(Festivo festivo)
        => Task.FromResult(db.Update(festivo));
    }
}
