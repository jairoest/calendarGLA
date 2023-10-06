
using PocketOne.Interfaces;

namespace PocketOne.Services
{
    internal class SubCategoriaService : ISubCategoria
    {
        private readonly SQLLiteHelper<SubCategoria> db;

        public SubCategoriaService()
        => db = new();

        public Task<int> Delete(SubCategoria subcategoria)
        => Task.FromResult(db.Delete(subcategoria));

        public Task<List<SubCategoria>> GetAll()
        => Task.FromResult(db.GetAll());

        public Task<SubCategoria> GetById(int id)
        => Task.FromResult(db.Get(id));

        public Task<int> Insert(SubCategoria subcategoria)
        => Task.FromResult(db.Insert(subcategoria));

        public Task<int> Update(SubCategoria subcategoria)
        => Task.FromResult(db.Update(subcategoria));

        public int LlenarSubCategoriasBase()
        {
            SubCategoria subcategoria1 = new()
            {
                IdCategoria = 1,
                NombreSubCategoria = "asda"
            };
            Insert(subcategoria1);


            subcategoria1 = new()
            {
                IdCategoria = 1,
                NombreSubCategoria = "Nomina"
            };
            Insert(subcategoria1);


            subcategoria1 = new()
            {
                IdCategoria = 2,
                NombreSubCategoria = "TC Scotia"
            };
            Insert(subcategoria1);


            subcategoria1 = new()
            {
                IdCategoria = 3,
                NombreSubCategoria = "Credito 1 Consumo Scotia"
            };
            Insert(subcategoria1);


            subcategoria1 = new()
            {
                IdCategoria = 3,
                NombreSubCategoria = "Credito 2 Libranza Scotia"
            };
            Insert(subcategoria1);


            subcategoria1 = new()
            {
                IdCategoria = 4,
                NombreSubCategoria = "Uni Andes"
            };
            Insert(subcategoria1);


            subcategoria1 = new()
            {
                IdCategoria = 4,
                NombreSubCategoria = "Gimnandes"
            };
            Insert(subcategoria1);


            subcategoria1 = new()
            {
                IdCategoria = 5,
                NombreSubCategoria = "Servicios ETB"
            };
            Insert(subcategoria1);


            subcategoria1 = new()
            {
                IdCategoria = 5,
                NombreSubCategoria = "Servicios Codensa"
            };
            Insert(subcategoria1);


            subcategoria1 = new()
            {
                IdCategoria = 5,
                NombreSubCategoria = "Servicios EAAB"
            };
            Insert(subcategoria1);


            subcategoria1 = new()
            {
                IdCategoria = 5,
                NombreSubCategoria = "Claro Patty"
            };
            Insert(subcategoria1);


            subcategoria1 = new()
            {
                IdCategoria = 5,
                NombreSubCategoria = "Claro Santi"
            };
            Insert(subcategoria1);


            subcategoria1 = new()
            {
                IdCategoria = 5,
                NombreSubCategoria = "Claro Jairo"
            };
            Insert(subcategoria1);


            subcategoria1 = new()
            {
                IdCategoria = 6,
                NombreSubCategoria = "Mercado Alkosto"
            };
            Insert(subcategoria1);


            subcategoria1 = new()
            {
                IdCategoria = 2,
                NombreSubCategoria = "TC Itau"
            };
            Insert(subcategoria1);


            subcategoria1 = new()
            {
                IdCategoria = 3,
                NombreSubCategoria = "Credito Itau"
            };
            Insert(subcategoria1);

            subcategoria1 = new()
            {
                IdCategoria = 3,
                NombreSubCategoria = "Credito AV Villas"
            };
            Insert(subcategoria1);


            subcategoria1 = new()
            {
                IdCategoria = 7,
                NombreSubCategoria = "Carro Gasolina"
            };
            Insert(subcategoria1);


            subcategoria1 = new()
            {
                IdCategoria = 6,
                NombreSubCategoria = "Mercado Naranjas"
            };
            Insert(subcategoria1);


            subcategoria1 = new()
            {
                IdCategoria = 4,
                NombreSubCategoria = "Utiles escolares"
            };
            Insert(subcategoria1);


            subcategoria1 = new()
            {
                IdCategoria = 8,
                NombreSubCategoria = "Ahorro predial"
            };
            Insert(subcategoria1);


            subcategoria1 = new()
            {
                IdCategoria = 3,
                NombreSubCategoria = "Credito Libranza"
            };
            Insert(subcategoria1);


            subcategoria1 = new()
            {
                IdCategoria = 9,
                NombreSubCategoria = "Cama Ana Maria"
            };
            Insert(subcategoria1);


            subcategoria1 = new()
            {
                IdCategoria = 9,
                NombreSubCategoria = "Comida Hatchiko"
            };
            Insert(subcategoria1);


            subcategoria1 = new()
            {
                IdCategoria = 10,
                NombreSubCategoria = "Comida"
            };
            Insert(subcategoria1);


            subcategoria1 = new()
            {
                IdCategoria = 10,
                NombreSubCategoria = "Ropa"
            };
            Insert(subcategoria1);


            subcategoria1 = new()
            {
                IdCategoria = 10,
                NombreSubCategoria = "Medicamentos"
            };
            Insert(subcategoria1);


            subcategoria1 = new()
            {
                IdCategoria = 5,
                NombreSubCategoria = "Servicios Luchi"
            };
            Insert(subcategoria1);


            subcategoria1 = new()
            {
                IdCategoria = 10,
                NombreSubCategoria = "Apoyo Diego"
            };
            Insert(subcategoria1);


            subcategoria1 = new()
            {
                IdCategoria = 7,
                NombreSubCategoria = "Gastos Carro"
            };
            Insert(subcategoria1);


            subcategoria1 = new()
            {
                IdCategoria = 9,
                NombreSubCategoria = "Gastos casa"
            };
            Insert(subcategoria1);

            subcategoria1 = new()
            {
                IdCategoria = 9,
                NombreSubCategoria = "Viaje Duitama"
            };
            Insert(subcategoria1);

            return 0;
        }
    }
}
