using PocketOne.Interfaces;
using PocketOne.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketOne.Services
{
    public class SQLiteBase
    {
        public SQLiteConnection connectionDB;

        /*
        private readonly IPeriodo periodo_service;
        private readonly ICategoria categoria_service;
        private readonly ISubCategoria subcategoria_service;
        private readonly IMovimiento movimiento_service;
        private readonly IDialogService dialog_service;
        */

        public SQLiteBase() 
        {
            /*
            periodo_service = App.Current.Services.GetRequiredService<IPeriodo>();
            categoria_service = App.Current.Services.GetRequiredService<ICategoria>();
            subcategoria_service = App.Current.Services.GetRequiredService<ISubCategoria>();
            movimiento_service = App.Current.Services.GetRequiredService<IMovimiento>();
            dialog_service = App.Current.Services.GetRequiredService<IDialogService>();
            */

            if (connectionDB != null) return;

            try
            {
                //dialog_service.Show("Conexion a la BD", $"Inicio. DBPath: {Constantes.DataBasePath}");
                connectionDB = new SQLiteConnection(Constantes.DataBasePath, Constantes.Flags);
                connectionDB.CreateTable<Periodo>();
                connectionDB.CreateTable<Categoria>();
                connectionDB.CreateTable<SubCategoria>();
                connectionDB.CreateTable<Movimiento>();

                //dialog_service.ShowConfirmationAsync("Conexion a la BD", "Inicio. PoblarDatos");
                /*
                var poblarDatos = Preferences.Get("PoblarDatos", true);
                if (poblarDatos) PoblarDatos();
                //dialog_service.ShowConfirmationAsync("Conexion a la BD", $"Inicio. Termino PoblarDatos");

                Preferences.Default.Set("PoblarDatos", false);
                */
            }
            catch (Exception ex)
            {
                //dialog_service.ShowConfirmationAsync("Exception", $"Inicio. Error: {ex.Message}");

                var basePath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData);
                
                using (StreamWriter sw = new StreamWriter(System.IO.Path.Combine(basePath, "logPocketOne.txt"), true))
                {
                    sw.WriteLine("SQLiteBase: " + DateTime.Now + " - " + ex.Message);
                }
            }
        }

        #region Data
        private void PoblarDatos()
        {

            // pendiente codigo para validar si hay registros y borrar. Evita Poblar duplicados
            // Llenar tabla de categorias
            LlenarCategoriasAsync();

            // Llenar tabla de subcategorias
            LlenarSubCategoriasAsync();

            // Llenar tabla de periodos
            LlenarPeriodosAsync();

            // Iniciar tabla de movimientos
            LlenarMovimientosAsync();

        }

        private async void LlenarCategoriasAsync()
        {
            // ****** Borrar contenido actual de la tabla de cursos
            /*
            var lista = await categoria_service.GetAll();
            if (lista.Count == 0) categoria_service.LlenarCategoriasBase();
            */
        }

        private async void LlenarSubCategoriasAsync()
        {
            /*
            var lista = await subcategoria_service.GetAll();
            if (lista.Count == 0) subcategoria_service.LlenarSubCategoriasBase();
            */
        }


        private async void LlenarPeriodosAsync()
        {
            /*
            var lista = await periodo_service.GetAll();
            if (lista.Count == 0) periodo_service.LlenarPeriodosBase();
            */
        }

        /// <summary>
        /// Llena la tabla de dias festivos y eventos. Estas fechas no se incluirán en el calendario académico
        /// </summary>
        private async void LlenarMovimientosAsync()
        {
            /*
            var lista = await movimiento_service.GetAll();
            if (lista.Count == 0) movimiento_service.LlenarMovimientosBase();
            */
        }
        #endregion
    }
}
