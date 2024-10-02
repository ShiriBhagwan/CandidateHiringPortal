using MyApp.Data;

namespace MyApp.Application
{
    public interface IUserService
    {
        Task<IEnumerable<UserDetails>> GetAllAsync();
        Task GetByIdAsync(int id);
        Task AddAsync(UserDetails entity);
        Task UpdateAsync(UserDetails entity);
        Task DeleteAsync(UserDetails entity);
    }
}
