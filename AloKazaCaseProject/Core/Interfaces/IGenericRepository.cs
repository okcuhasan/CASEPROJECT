namespace AloKazaCaseProject.Core.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T?> GetById(int id); // get data by id

        Task<IEnumerable<T>> GetAll(); // get all data

        Task<bool> Add(T entity); // add data

        Task<bool> Remove(int id); // remove data by id

        Task<bool> Update(T entity); // update data
    }
}
