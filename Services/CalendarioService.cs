
namespace CalendarAE.Services
{
    internal class CalendarioService : ICalendario
    {
        private readonly SQLLiteHelper<Calendario> db;

        private IFestivo festivo_service;

        public CalendarioService()
        => db = new();

        public Task<int> Delete(Calendario calendario)
        => Task.FromResult(db.Delete(calendario));

        public Task<List<Calendario>> GetAll()
        => Task.FromResult(db.GetAll());

        public Task<Calendario> GetById(int id)
        => Task.FromResult(db.Get(id));

        public Task<Calendario> GetByDate(DateTime fecha)
        => Task.FromResult(db.connectionDB.Table<Calendario>().Where(w => w.Fecha == fecha).FirstOrDefault());

        public Task<int> Insert(Calendario calendario)
        => Task.FromResult(db.Insert(calendario));

        public Task<int> Update(Calendario calendario)
        => Task.FromResult(db.Update(calendario));

        public int LlenarCalendarioBase()
        {
            // Llenar datos iniciales
            // DateTime fecha = new (2024, 01, 26);
            // DateTime fechaFinal = new (2024, 12, 06);

            DateTime fecha = Preferences.Default.Get("FechaInicioPeriodo", new DateTime(2024, 02, 26, 0, 0, 0));
            DateTime fechaFinal = Preferences.Default.Get("FechaFinPeriodo", new DateTime(2024, 11, 06, 0, 0, 0));

            byte dia = 1;
            bool esfestivo = true;
            bool reiniciar = false;
            int diafestivo = 0;
            string infodia = string.Empty;
            Calendario calendario;
            Festivo festivo;

            festivo_service = App.Current.Services.GetService<IFestivo>();

            while (fecha < fechaFinal)
            {
                festivo = festivo_service.GetByFecha(fecha).Result;
                if (festivo == null)
                {
                    if (fecha.DayOfWeek == System.DayOfWeek.Saturday || fecha.DayOfWeek == System.DayOfWeek.Sunday)
                    {
                        diafestivo = 2; // Festivo normal fin de semana
                        esfestivo = true;
                        infodia = "Fin de semana";
                    }
                    else
                    {
                        // Dia de clase normal
                        diafestivo = 0;
                        esfestivo = false;
                        infodia = null;
                    }
                }
                else
                {
                    if (festivo.Tipo != 0)
                    {
                        // Incluido en la lista de festivos, incluyendo eventos sin clase y vacaciones
                        esfestivo = true;
                        diafestivo = festivo.Tipo;
                        reiniciar = festivo.Tipo == 0;
                    }
                    else
                    {
                        // Eventos del colegio con clase. No festivo en el calendario
                        diafestivo = 0;
                        esfestivo = false;
                    }

                    infodia = festivo.Descripcion;
                }

                calendario = new Calendario
                {
                    Fecha = fecha,
                    Dia = (byte)(esfestivo ? 0 : dia),
                    Tipo = esfestivo ? diafestivo : 0,
                    Observaciones = infodia
                };

                Insert(calendario);

                if (!esfestivo && calendario.Tipo == 0) dia++;

                if (dia == 7 || reiniciar)
                {
                    dia = 1;
                    reiniciar = false;
                }

                fecha = fecha.AddDays(1);
            }


            return 0;

        }
    }
}
