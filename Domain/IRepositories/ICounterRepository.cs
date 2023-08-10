
namespace Domain.IRepositories
{
    public interface ICounterRepository
    {
        Task<int> GetNextIdAsync(string counterId);
    }
}
