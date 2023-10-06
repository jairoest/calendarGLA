
namespace PocketOne.Services
{
    public class SQLLiteHelper<T> : SQLiteBase where T : BaseModel, new()
    {
        public List<T> GetAll()
        => connectionDB.Table<T>().ToList();

        public int Insert(T row)
        {
            connectionDB.Insert(row);
            return row.Id;
        }

        public int Update(T row) 
        => connectionDB.Update(row);
            
        public int Delete(T row) 
        => connectionDB.Delete(row);

        public T Get(int id)
        => connectionDB.Table<T>().Where(w=> w.Id == id).FirstOrDefault();

    }
}
