namespace TaskManagement.Core.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAllAsync();
        IQueryable<T> GetQueryAble();
        Task Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        Task<int> SaveChangesAsync();
    }
}
