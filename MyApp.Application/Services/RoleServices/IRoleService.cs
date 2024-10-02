using MyApp.Application.Dtos.RoleDtos;
using MyApp.Data;

namespace MyApp.Application
{
    public interface IRoleService
    {
        Task<IEnumerable<RoleDto>> GetAllAsync();
        Task<RoleDto> GetByIdAsync(int id);
        Task AddAsync(RoleDto entity);
        Task UpdateAsync(RoleDto entity);
        Task DeleteAsync(int id);
    }
}
