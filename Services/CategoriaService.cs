
namespace PocketOne.Services
{
    internal class CategoriaService : ICategoria
    {
        private readonly SQLLiteHelper<Categoria> db;

        public CategoriaService()
        => db = new();

        public Task<int> Delete(Categoria categoria)
        => Task.FromResult(db.Delete(categoria));

        public Task<List<Categoria>> GetAll()
        => Task.FromResult(db.GetAll());

        public Task<Categoria> GetById(int id)
        => Task.FromResult(db.Get(id));

        public Task<int> Insert(Categoria categoria)
        => Task.FromResult(db.Insert(categoria));

        public Task<int> Update(Categoria categoria)
        => Task.FromResult(db.Update(categoria));

        public int LlenarCategoriasBase()
        {
            Categoria categoria1 = new()
            {
                NombreCategoria = "Nomina",
                TipoMovimiento = "Ingreso"
            };
            Insert(categoria1);

            Categoria categoria2 = new()
            {
                NombreCategoria = "TC", TipoMovimiento="Egreso"
            };
            Insert(categoria2);

            Categoria categoria3 = new()
            {
                NombreCategoria = "Credito", TipoMovimiento = "Egreso"
            };
            Insert(categoria3);

            Categoria categoria4 = new()
            {
                NombreCategoria = "Estudio", TipoMovimiento = "Egreso"
            };
            Insert(categoria4);

            Categoria categoria5 = new()
            {
                NombreCategoria = "Servicios", TipoMovimiento = "Egreso"
            };
            Insert(categoria5);

            Categoria categoria6 = new()
            {
                NombreCategoria = "Mercado",
                TipoMovimiento = "Egreso"
            };
            Insert(categoria6);

            Categoria categoria7 = new()
            {
                NombreCategoria = "Carro",
                TipoMovimiento = "Egreso"
            };
            Insert(categoria7);

            Categoria categoria8 = new()
            {
                NombreCategoria = "Ahorro",
                TipoMovimiento = "Egreso"
            };
            Insert(categoria8);

            Categoria categoria9 = new()
            {
                NombreCategoria = "Casa",
                TipoMovimiento = "Egreso"
            };
            Insert(categoria9);

            Categoria categoria10 = new()
            {
                NombreCategoria = "Varios",
                TipoMovimiento = "Egreso"
            };
            Insert(categoria10);

            return 0;

        }
    }
}
