using MyApp.Data;

namespace MyApp.Application.Services.UserServices
{
    public class UserService : IUserService
    {
        public Task AddAsync(UserDetails entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(UserDetails entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserDetails>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(UserDetails entity)
        {
            throw new NotImplementedException();
        }
    }
}
