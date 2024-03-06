namespace CustomerService.Interfaces.Repositories
{
    public interface IGenericRepository<T>
    {
        Task<T> Get(int id);
        Task<List<T>> Get();
        Task<T> Post(T entity);
        Task<T> Put(T entity);
        Task<T> Delete(T entity);
    }
}
