
using CalendarAE.Interfaces;

namespace CalendarAE.Services
{
    internal class HorarioService : IHorario
    {
        private readonly SQLLiteHelper<Horario> db;

        private ICalendario calendario_service;

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

        public Task<List<Horario>> GetByCurso(string curso)
        => Task.FromResult(db.connectionDB.Table<Horario>().Where(w => w.NombreCurso == curso).ToList());

        public Task<int> Insert(Horario horario)
        => Task.FromResult(db.Insert(horario));

        public Task<int> Update(Horario horario)
        => Task.FromResult(db.Update(horario));

        public async Task<int> LlenarHorarioBase()
        {
            List<Horario> listaHorario = new();
            Horario clase;

            calendario_service = App.Current.Services.GetService<ICalendario>();

            var listaCalendario = await calendario_service.GetAll();

            DateTime diaActual = DateTime.Today;
            string cursoActual = Preferences.Default.Get("CursoActual", "4A");

            #region Datos base por dia
            List<Horario> listaHorarioDia = new()
            {
                new Horario().NuevoHorario(cursoActual, 1, new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 7, 15, 0), new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 7, 30, 0), "Acogida", false),
                new Horario().NuevoHorario(cursoActual, 1, new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 7, 30, 0), new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 8, 20, 0), "Tutoría", false),
                new Horario().NuevoHorario(cursoActual, 1, new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 8, 20, 0), new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 9, 10, 0), "Math", false),
                new Horario().NuevoHorario(cursoActual, 1, new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 9, 10, 0), new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 9, 50, 0), "Break", false),
                new Horario().NuevoHorario(cursoActual, 1, new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 9, 50, 0), new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 10, 40, 0), "English", false),
                new Horario().NuevoHorario(cursoActual, 1, new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 10, 40, 0), new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 11, 30, 0), "Physical Education", false),
                new Horario().NuevoHorario(cursoActual, 1, new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 11, 30, 0), new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 12, 15, 0), "Physical Education", false),
                new Horario().NuevoHorario(cursoActual, 1, new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 12, 15, 0), new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 13, 15, 0), "Lunch", false),
                new Horario().NuevoHorario(cursoActual, 1, new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 13, 15, 0), new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 14, 00, 0), "Lenguaje", false),
                new Horario().NuevoHorario(cursoActual, 1, new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 14, 00, 0), new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 14, 40, 0), "Lenguaje", false),
                new Horario().NuevoHorario(cursoActual, 1, new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 14, 40, 0), new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 14, 50, 0), "Despedida", false),

                new Horario().NuevoHorario(cursoActual, 2, new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 7, 15, 0), new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 7, 30, 0), "Acogida", false),
                new Horario().NuevoHorario(cursoActual, 2, new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 7, 30, 0), new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 8, 20, 0), "Math", false),
                new Horario().NuevoHorario(cursoActual, 2, new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 8, 20, 0), new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 9, 10, 0), "Math", false),
                new Horario().NuevoHorario(cursoActual, 2, new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 9, 10, 0), new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 9, 50, 0), "Break", false),
                new Horario().NuevoHorario(cursoActual, 2, new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 9, 50, 0), new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 10, 40, 0), "Ciencias Sociales", false),
                new Horario().NuevoHorario(cursoActual, 2, new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 10, 40, 0), new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 11, 30, 0), "Science", false),
                new Horario().NuevoHorario(cursoActual, 2, new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 11, 30, 0), new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 12, 15, 0), "Lenguaje", false),
                new Horario().NuevoHorario(cursoActual, 2, new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 12, 15, 0), new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 13, 15, 0), "Lunch", false),
                new Horario().NuevoHorario(cursoActual, 2, new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 13, 15, 0), new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 14, 00, 0), "English", false),
                new Horario().NuevoHorario(cursoActual, 2, new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 14, 00, 0), new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 14, 40, 0), "English", false),
                new Horario().NuevoHorario(cursoActual, 2, new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 14, 40, 0), new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 14, 50, 0), "Despedida", false),

                new Horario().NuevoHorario(cursoActual, 3, new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 7, 15, 0), new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 7, 30, 0), "Acogida", false),
                new Horario().NuevoHorario(cursoActual, 3, new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 7, 30, 0), new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 8, 20, 0), "Arts", false),
                new Horario().NuevoHorario(cursoActual, 3, new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 8, 20, 0), new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 9, 10, 0), "Arts", false),
                new Horario().NuevoHorario(cursoActual, 3, new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 9, 10, 0), new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 9, 50, 0), "Break", false),
                new Horario().NuevoHorario(cursoActual, 3, new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 9, 50, 0), new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 10, 40, 0), "Science", false),
                new Horario().NuevoHorario(cursoActual, 3, new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 10, 40, 0), new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 11, 30, 0), "Aprendizaje SE", false),
                new Horario().NuevoHorario(cursoActual, 3, new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 11, 30, 0), new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 12, 15, 0), "Computer Science", false),
                new Horario().NuevoHorario(cursoActual, 3, new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 12, 15, 0), new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 13, 15, 0), "Lunch", false),
                new Horario().NuevoHorario(cursoActual, 3, new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 13, 15, 0), new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 14, 00, 0), "Lenguaje", false),
                new Horario().NuevoHorario(cursoActual, 3, new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 14, 00, 0), new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 14, 40, 0), "Lenguaje", false),
                new Horario().NuevoHorario(cursoActual, 3, new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 14, 40, 0), new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 14, 50, 0), "Despedida", false),

                new Horario().NuevoHorario(cursoActual, 4, new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 7, 15, 0), new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 7, 30, 0), "Acogida", false),
                new Horario().NuevoHorario(cursoActual, 4, new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 7, 30, 0), new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 8, 20, 0), "Ciencias Sociales", false),
                new Horario().NuevoHorario(cursoActual, 4, new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 8, 20, 0), new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 9, 10, 0), "Lenguaje", false),
                new Horario().NuevoHorario(cursoActual, 4, new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 9, 10, 0), new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 9, 50, 0), "Break", false),
                new Horario().NuevoHorario(cursoActual, 4, new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 9, 50, 0), new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 10, 40, 0), "Science", false),
                new Horario().NuevoHorario(cursoActual, 4, new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 10, 40, 0), new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 11, 30, 0), "Science", false),
                new Horario().NuevoHorario(cursoActual, 4, new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 11, 30, 0), new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 12, 15, 0), "English", false),
                new Horario().NuevoHorario(cursoActual, 4, new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 12, 15, 0), new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 13, 15, 0), "Lunch", false),
                new Horario().NuevoHorario(cursoActual, 4, new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 13, 15, 0), new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 14, 00, 0), "Sports", false),
                new Horario().NuevoHorario(cursoActual, 4, new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 14, 00, 0), new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 14, 40, 0), "Sports", false),
                new Horario().NuevoHorario(cursoActual, 4, new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 14, 40, 0), new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 14, 50, 0), "Despedida", false),

                new Horario().NuevoHorario(cursoActual, 5, new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 7, 15, 0), new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 7, 30, 0), "Acogida", false),
                new Horario().NuevoHorario(cursoActual, 5, new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 7, 30, 0), new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 8, 20, 0), "Math", false),
                new Horario().NuevoHorario(cursoActual, 5, new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 8, 20, 0), new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 9, 10, 0), "Math", false),
                new Horario().NuevoHorario(cursoActual, 5, new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 9, 10, 0), new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 9, 50, 0), "Break", false),
                new Horario().NuevoHorario(cursoActual, 5, new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 9, 50, 0), new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 10, 40, 0), "Ciencias Sociales", false),
                new Horario().NuevoHorario(cursoActual, 5, new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 10, 40, 0), new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 11, 30, 0), "Ciencias Sociales", false),
                new Horario().NuevoHorario(cursoActual, 5, new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 11, 30, 0), new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 12, 15, 0), "Etica", false),
                new Horario().NuevoHorario(cursoActual, 5, new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 12, 15, 0), new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 13, 15, 0), "Lunch", false),
                new Horario().NuevoHorario(cursoActual, 5, new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 13, 15, 0), new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 14, 00, 0), "English", false),
                new Horario().NuevoHorario(cursoActual, 5, new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 14, 00, 0), new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 14, 40, 0), "English", false),
                new Horario().NuevoHorario(cursoActual, 5, new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 14, 40, 0), new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 14, 50, 0), "Despedida", false),

                new Horario().NuevoHorario(cursoActual, 6, new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 7, 15, 0), new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 7, 30, 0), "Acogida", false),
                new Horario().NuevoHorario(cursoActual, 6, new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 7, 30, 0), new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 8, 20, 0), "Computer Science", false),
                new Horario().NuevoHorario(cursoActual, 6, new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 8, 20, 0), new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 9, 10, 0), "Computer Science", false),
                new Horario().NuevoHorario(cursoActual, 6, new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 9, 10, 0), new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 9, 50, 0), "Break", false),
                new Horario().NuevoHorario(cursoActual, 6, new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 9, 50, 0), new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 10, 40, 0), "Science", false),
                new Horario().NuevoHorario(cursoActual, 6, new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 10, 40, 0), new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 11, 30, 0), "Science", false),
                new Horario().NuevoHorario(cursoActual, 6, new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 11, 30, 0), new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 12, 15, 0), "Lenguaje", false),
                new Horario().NuevoHorario(cursoActual, 6, new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 12, 15, 0), new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 13, 15, 0), "Lunch", false),
                new Horario().NuevoHorario(cursoActual, 6, new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 13, 15, 0), new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 14, 00, 0), "English", false),
                new Horario().NuevoHorario(cursoActual, 6, new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 14, 00, 0), new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 14, 40, 0), "English", false),
                new Horario().NuevoHorario(cursoActual, 6, new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 14, 40, 0), new DateTime(diaActual.Year, diaActual.Month, diaActual.Day, 14, 50, 0), "Despedida", false)
            };
            #endregion

            foreach(var calendario in listaCalendario)
            {
                // Agregar un evento de todo el dia para la vista de horario, indicando el dia academico
                if (calendario.Dia != 0)
                {


                    clase = new()
                    {
                        NombreCurso = cursoActual,
                        Dia = calendario.Dia,
                        HoraInicio = new DateTime(calendario.Fecha.Year, calendario.Fecha.Month, calendario.Fecha.Day, 7, 00, 00),
                        HoraFin = new DateTime(calendario.Fecha.Year, calendario.Fecha.Month, calendario.Fecha.Day, 15, 00, 00),
                        Materia = $"Día {calendario.Dia}",
                        EsTodoElDia = true
                        // ColorFondo = horario.ColorFondo
                    };

                    listaHorario.Add(clase);
                }

                var clasesDia = listaHorarioDia.Where(e => e.Dia == calendario.Dia);

                foreach (Horario horario in clasesDia)
                {
                    clase = new()
                    {
                        NombreCurso = cursoActual,
                        Dia = horario.Dia,
                        HoraInicio = new DateTime(calendario.Fecha.Year, calendario.Fecha.Month, calendario.Fecha.Day, horario.HoraInicio.Hour, horario.HoraInicio.Minute, horario.HoraInicio.Second),
                        HoraFin = new DateTime(calendario.Fecha.Year, calendario.Fecha.Month, calendario.Fecha.Day, horario.HoraFin.Hour, horario.HoraFin.Minute, horario.HoraFin.Second),
                        Materia = horario.Materia,
                        EsTodoElDia = horario.EsTodoElDia
                        // ColorFondo = horario.ColorFondo
                    };

                    listaHorario.Add(clase);
                }
            }

            foreach (Horario horario in listaHorario)
            {
                await Insert(horario);
            }

            return 0;
        }
    }
}
