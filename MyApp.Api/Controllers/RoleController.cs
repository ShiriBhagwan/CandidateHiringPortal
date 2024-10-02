using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application;
using MyApp.Application.Dtos.RoleDtos;

namespace MyApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            var data = await _roleService.GetAllAsync();
            return Ok(data);
        }

        [HttpGet]
        public async Task<ActionResult> GetById(int id)
        {
            var data = await _roleService.GetByIdAsync(id);
            return Ok(data);
        }


        [HttpPost]
        public async Task<ActionResult> Add(RoleDto input)
        {
            await _roleService.AddAsync(input);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update(RoleDto input)
        {
              await _roleService.UpdateAsync(input);
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int Id)
        {
            await _roleService.DeleteAsync(Id);
            return Ok();
        }
    }
}
