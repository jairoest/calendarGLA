
namespace PocketOne.Interfaces
{
    internal interface ICategoria
    {
        public Task<List<Categoria>> GetAll();

        public Task<Categoria> GetById(int id);

        public Task<int> Insert(Categoria categoria);

        public Task<int> Update(Categoria categoria);

        public Task<int> Delete(Categoria categoria);

        public int LlenarCategoriasBase();

    }
}
