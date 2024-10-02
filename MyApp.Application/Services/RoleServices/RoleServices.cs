using MyApp.Application.Dtos.RoleDtos;
using MyApp.Data;
using MyApp.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application
{
    public class RoleServices : IRoleService
    {
        private readonly IGenericRepository<Role> _role;
        public RoleServices(IGenericRepository<Role> role)
        {
            _role = role;
        }
        public async Task AddAsync(RoleDto entity)
        {
            Role role = new Role()
            {
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                Name = entity.Name,
                IsDeleted = false
            };
            await _role.AddAsync(role);
            var result = OperationHandler<Role>.Success(null);
            return;


        }

        public async Task DeleteAsync(int id)
        {
            var data = await _role.GetByIdAsync(id);
            if (data != null)
            {
                _role.DeleteAsync(data);
            }
            return;
        }

        public async Task<IEnumerable<RoleDto>> GetAllAsync()
        {
            var data = await _role.GetAllAsync();
            var result = data.Select(x => new RoleDto() { CreatedDate = x.CreatedDate, Id = x.Id, UpdatedDate = x.UpdatedDate, Name = x.Name, IsDeleted = x.IsDeleted });
            return result;
        }

        public async Task<RoleDto> GetByIdAsync(int id)
        {
            var data = await _role.GetByIdAsync(id);
            var result = new RoleDto()
            {
                IsDeleted = data.IsDeleted,
                Name = data.Name,
                UpdatedDate = data.UpdatedDate,
                CreatedDate = data.CreatedDate,
                Id = data.Id
            };
            return result;
        }

        public async Task UpdateAsync(RoleDto entity)
        {
            Role role = new Role()
            {
                Id = entity.Id,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                Name = entity.Name,
                IsDeleted = false
            };
            await _role.UpdateAsync(role);
            var result = OperationHandler<Role>.Success(null);
            return;
        }
    }
}
