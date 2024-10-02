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
        public async Task<ActionResult<IEnumerable<CandidateViewDto>>> GetAll()
        {
            var data = await _candidate.GetAllAsync();
            var result = data;
            return Ok(result);
        }
        [HttpGet("Getall")]
        public async Task<ActionResult<IEnumerable<CandidateViewDto>>> GetById(int id)
        {
            var data = await _candidate.GetByIdAsync(id);
            var result = data;
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<IEnumerable<CandidateViewDto>>> Add(CreateUpdateCandidateDto data)
        {
            var result = await _candidate.AddAsync(data);
            return Ok(result);
        }
        [HttpPut]
        public async Task<ActionResult> Update(CreateUpdateCandidateDto data)
        {
            var result = await _candidate.UpdateAsync(data);
            return Ok(result);
        }
        [HttpDelete]
        public  async Task<ActionResult> Remove(int id)
        {
            var result = await _candidate.DeleteAsync(id);
            return Ok(result);
        }
    }
}
