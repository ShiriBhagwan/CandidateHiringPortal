using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application;
using MyApp.Application.Dtos.CandidateDtos;

namespace MyApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatesController : ControllerBase
    {
        private readonly ICandidateService _candidate;
        public CandidatesController(ICandidateService candidate)
        {
            _candidate = candidate;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var data = await _candidate.GetAllAsync();
            var result = data;
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var data = await _candidate.GetByIdAsync(id);
            var result = data;
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult> Post(CandidateCreateDto data)
        {
            var result = await _candidate.AddAsync(data);
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(CandidateUpdateDto data,int id)
        {
            data.Id = id;
            var result = await _candidate.UpdateAsync(data);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public  async Task<ActionResult> Delete(int id)
        {
            var result = await _candidate.DeleteAsync(id);
            return Ok(result);
        }
    }
}
