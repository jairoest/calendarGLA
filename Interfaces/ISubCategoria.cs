
namespace PocketOne.Interfaces
{
    internal interface ISubCategoria
    {
        public Task<List<SubCategoria>> GetAll();

        public Task<SubCategoria> GetById(int id);

        public Task<int> Insert(SubCategoria subcategoria);

        public Task<int> Update(SubCategoria subcategoria);

        public Task<int> Delete(SubCategoria subcategoria);

        public int LlenarSubCategoriasBase();

    }
}
