namespace Domain.IRepositories
{
        public interface IBaseRepository<T>
        {
            Task<T> GetByIdAsync(int? id);
            Task<IEnumerable<T>> GetAllAsync();
            Task<T> CreateAsync(T entity);
            Task UpdateAsync(int id, T entity);
            Task DeleteAsync(int id);

        }
    }
