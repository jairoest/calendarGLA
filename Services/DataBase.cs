using PocketOne.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketOne.Services
{
    internal class DataBase
    {
        readonly SQLiteAsyncConnection _database;

        public DataBase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);

            // Tablas base
            _database.CreateTableAsync<Categoria>().Wait();
            _database.CreateTableAsync<Periodo>().Wait();
            _database.CreateTableAsync<SubCategoria>().Wait();

            // Tabla de movimientos
            _database.CreateTableAsync<Movimiento>().Wait();

            var poblarDatos = Preferences.Get("PoblarDatos", true);
            if (poblarDatos) PoblarDatos();
            Preferences.Default.Set("PoblarDatos", false);

        }

        #region Tabla Categoria
        public Task<List<Categoria>> GetCategoriaAsync()
        {
            return _database.Table<Categoria>().ToListAsync();
        }

        public Task<int> SaveCategoriaAsync(Categoria categoria)
        {
            return _database.InsertAsync(categoria);
        }

        public Task<int> DeleteCategoriaAsync()
        {
            return _database.DeleteAllAsync<Categoria>();
        }

        public Task<int> GetCategoriaCount()
        {
            return _database.Table<Categoria>().CountAsync();
        }
        #endregion

        #region Tabla Movimiento
        public Task<List<Movimiento>> GetMovimientoAsync()
        {
            return _database.Table<Movimiento>().ToListAsync();
        }

        /// <summary>
        /// Leer la lista de movimientos de un periodo seleccionado
        /// </summary>
        /// <param name="fechaperiodo">Fecha que identifica el periodo (mes) seleccionado</param>
        /// <returns></returns>
        public Task<Movimiento> GetMovimientosbyPeriodoAsync(DateTime fechaperiodo)
        {
            return _database.Table<Movimiento>().Where(a => a.FechaPeriodo == fechaperiodo).FirstOrDefaultAsync();
        }


        public Task<int> SaveMovimientoAsync(Movimiento movimiento)
        {
            return _database.InsertAsync(movimiento);
        }

        public Task<int> DeleteMovimientoAsync()
        {
            return _database.DeleteAllAsync<Movimiento>();
        }

        public Task<int> GetMovimientoCount()
        {
            return _database.Table<Movimiento>().CountAsync();
        }
        #endregion

        #region Tabla Periodo
        public Task<List<Periodo>> GetCursosAsync()
        {
            return _database.Table<Periodo>().ToListAsync();
        }

        /// <summary>
        /// Leer un item de la tabla de periodo por fecha
        /// </summary>
        /// <param name="fecha">Fecha seleccionada</param>
        /// <returns></returns>
        public Task<Periodo> GetPeriodobyFechaAsync(DateTime fecha)
        {
            return _database.Table<Periodo>().Where(a => a.FechaPeriodo == fecha).FirstOrDefaultAsync();
        }


        public Task<int> SavePeriodoAsync(Periodo periodo)
        {
            return _database.InsertAsync(periodo);
        }

        public Task<int> DeletePeriodoAsync()
        {
            return _database.DeleteAllAsync<Periodo>();
        }

        public Task<int> GetPeriodosCount()
        {
            return _database.Table<Periodo>().CountAsync();
        }
        #endregion

        #region Tabla SubCategoria
        public Task<List<SubCategoria>> GetSubCategoriaAsync()
        {
            return _database.Table<SubCategoria>().ToListAsync();
        }

        /// <summary>
        /// Leer un item de la tabla de SubCategorias por Id
        /// </summary>
        /// <param name="idcategoria">Id Categoria seleccionada</param>
        /// <returns></returns>
        public Task<List<SubCategoria>> GetSubCategoriabyIdAsync(byte idcategoria)
        {
            return _database.Table<SubCategoria>().Where(a => a.IdCategoria == idcategoria).ToListAsync();
        }


        public Task<int> SaveSubCategoriaAsync(SubCategoria subcategoria)
        {
            return _database.InsertAsync(subcategoria);
        }

        public Task<int> DeleteSubCategoriaAsync()
        {
            return _database.DeleteAllAsync<SubCategoria>();
        }

        public Task<int> GetSubCategoriaCount()
        {
            return _database.Table<SubCategoria>().CountAsync();
        }
        #endregion

        #region Data
        private async void PoblarDatos()
        {
            // ****** Borrar contenido actual de la BD
            int nroRegistros = await GetMovimientoCount();
            int borrados = await DeleteMovimientoAsync();

            LlenarCategoriasAsync();

            LlenarSubCategoriasAsync();

            LlenarPeriodosAsync();

            LlenarMovimientosAsync();

        }

        private async void LlenarCategoriasAsync()
        {
            // ****** Borrar contenido actual de la tabla de cursos
            int nroRegistros = await GetCategoriaCount();
            int borrados = await DeleteCategoriaAsync();

            if (nroRegistros == 0)
            {
                List<Categoria> listaCategorias = new ()
                {
                    new Categoria().Nuevo("Nomina", "Ingreso"),
                    new Categoria().Nuevo("TC", "Egreso"),
                    new Categoria().Nuevo("Credito", "Egreso"),
                    new Categoria().Nuevo("Estudio", "Egreso"),
                    new Categoria().Nuevo("Servicios", "Egreso"),
                    new Categoria().Nuevo("Mercado", "Egreso"),
                    new Categoria().Nuevo("Carro", "Egreso"),
                    new Categoria().Nuevo("Ahorro", "Egreso"),
                    new Categoria().Nuevo("Casa", "Egreso"),
                    new Categoria().Nuevo("Varios", "Egreso")
                };

                foreach (Categoria categoria in listaCategorias)
                {
                    await SaveCategoriaAsync(categoria);
                }
            }
        }

        private async void LlenarSubCategoriasAsync()
        {
            // ****** Borrar contenido actual de la tabla de cursos
            int nroRegistros = await GetSubCategoriaCount();
            int borrados = await DeleteSubCategoriaAsync();

            if (nroRegistros == 0)
            {
                List<SubCategoria> listaSubCategorias = new()
                {
                    new SubCategoria().Nuevo(1, "Nomina"),
                    new SubCategoria().Nuevo(2, "TC Scotia"),
                    new SubCategoria().Nuevo(3, "Credito 1 Consumo Scotia"),
                    new SubCategoria().Nuevo(3, "Credito 2 Libranza Scotia"),
                    new SubCategoria().Nuevo(4, "Uni Andes"),
                    new SubCategoria().Nuevo(4, "Gimandes"),
                    new SubCategoria().Nuevo(5, "Servicios ETB"),
                    new SubCategoria().Nuevo(5, "Servicios Codensa"),
                    new SubCategoria().Nuevo(5, "Servicios EAAB"),
                    new SubCategoria().Nuevo(5, "Claro Patty"),
                    new SubCategoria().Nuevo(5, "Claro Santi"),
                    new SubCategoria().Nuevo(5, "Claro Jairo"),
                    new SubCategoria().Nuevo(6, "Mercado Alkosto"),
                    new SubCategoria().Nuevo(2, "TC Itau"),
                    new SubCategoria().Nuevo(2, "Credito Itau"),
                    new SubCategoria().Nuevo(3, "Credito AV Villas"),
                    new SubCategoria().Nuevo(7, "Carro Gasolina"),
                    new SubCategoria().Nuevo(6, "Mercado Naranjas"),
                    new SubCategoria().Nuevo(4, "Utiles escolares"),
                    new SubCategoria().Nuevo(8, "Ahorro predial"),
                    new SubCategoria().Nuevo(3, "Credito Libranza"),
                    new SubCategoria().Nuevo(9, "Cama Ana Maria"),
                    new SubCategoria().Nuevo(9, "Comida Hatchiko"),
                    new SubCategoria().Nuevo(10, "Comida"),
                    new SubCategoria().Nuevo(10, "Ropa"),
                    new SubCategoria().Nuevo(10, "Medicamentos"),
                    new SubCategoria().Nuevo(5, "Servicios Luchi"),
                    new SubCategoria().Nuevo(10, "Apoyo Diego"),
                    new SubCategoria().Nuevo(7, "Gastos Carro"),
                    new SubCategoria().Nuevo(9, "Viaje Duitama"),
                    new SubCategoria().Nuevo(9, "Gastos casa")

                };

                foreach (SubCategoria subcategoria in listaSubCategorias)
                {
                    await SaveSubCategoriaAsync(subcategoria);
                }
            }
        }


        private async void LlenarPeriodosAsync()
        {
            // ****** Borrar contenido actual de la tabla de cursos
            int nroRegistros = await GetPeriodosCount();
            int borrados = await DeletePeriodoAsync();

            List<Periodo> listaPeriodo = new ()
            {
                new Periodo().Nuevo(new DateTime(2023, 06, 30)),
                new Periodo().Nuevo(new DateTime(2023, 07, 31)),
                new Periodo().Nuevo(new DateTime(2023, 08, 31))
            };

            foreach (Periodo periodo in listaPeriodo)
            {
                await SavePeriodoAsync(periodo);
            }
        }

        /// <summary>
        /// Llena la tabla de dias festivos y eventos. Estas fechas no se incluirán en el calendario académico
        /// </summary>
        private async void LlenarMovimientosAsync()
        {
            // ****** Borrar contenido actual de la tabla de festivos
            int nroRegistros = await GetMovimientoCount();
            int borrados = await DeleteMovimientoAsync();

            List<Movimiento> listaMovimientos = new List<Movimiento>
            {
                new Movimiento().Nuevo(new System.DateTime(2023, 06, 30), "Nomina", "Ingreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 06, 30), "TC Scotia", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 06, 30), "Credito 1 Consumo Scotia", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 06, 30), "Credito 2 Libranza Scotia", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 06, 30), "Uni Andes", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 06, 30), "Gimandes", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 06, 30), "Servicios ETB", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 06, 30), "Servicios Codensa", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 06, 30), "Servicios EAAB", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 06, 30), "ETB Jairo", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 06, 30), "Mercado Alkosto", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 06, 30), "TC Itau", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 06, 30), "Credito AV Villas", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 06, 30), "Credito AV Villas2 Predial", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 06, 30), "Carro Gasolina", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 06, 30), "Mercado Naranjas", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 06, 30), "Comida Hatchiko", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 06, 30), "Comida", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),

                new Movimiento().Nuevo(new System.DateTime(2023, 07, 31), "Nomina", "Ingreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 07, 31), "TC Scotia", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 07, 31), "Credito 1 Consumo Scotia", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 07, 31), "Credito 2 Libranza Scotia", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 07, 31), "Uni Andes", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 07, 31), "Gimandes", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 07, 31), "Servicios ETB", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 07, 31), "Servicios Codensa", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 07, 31), "Servicios EAAB", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 07, 31), "ETB Jairo", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 07, 31), "Mercado Alkosto", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 07, 31), "TC Itau", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 07, 31), "Credito AV Villas", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 07, 31), "Credito AV Villas2 Predial", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 07, 31), "Carro Gasolina", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 07, 31), "Mercado Naranjas", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 07, 31), "Comida Hatchiko", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 07, 31), "Comida", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),

                new Movimiento().Nuevo(new System.DateTime(2023, 08, 31), "Nomina", "Ingreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 08, 31), "TC Scotia", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 08, 31), "Credito 1 Consumo Scotia", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 08, 31), "Credito 2 Libranza Scotia", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 08, 31), "Uni Andes", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 08, 31), "Gimandes", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 08, 31), "Servicios ETB", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 08, 31), "Servicios Codensa", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 08, 31), "Servicios EAAB", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 08, 31), "ETB Jairo", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 08, 31), "Mercado Alkosto", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 08, 31), "TC Itau", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 08, 31), "Credito AV Villas", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 08, 31), "Credito AV Villas2 Predial", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 08, 31), "Carro Gasolina", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 08, 31), "Mercado Naranjas", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 08, 31), "Comida Hatchiko", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true),
                new Movimiento().Nuevo(new System.DateTime(2023, 08, 31), "Comida", "Egreso", 14430000, new System.DateTime(2023, 06, 25), new System.DateTime(2023, 06, 17), true)

            };

            foreach (Movimiento movimiento in listaMovimientos)
            {
                await SaveMovimientoAsync(movimiento);
            }

        }
        #endregion

    }
}
