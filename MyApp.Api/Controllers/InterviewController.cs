using Microsoft.AspNetCore.Mvc;
using MyApp.Application;
using MyApp.Application.Dtos.Interviewdtos;
using MyApp.Application.Services.InterviewServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterviewController : ControllerBase
    {
        private readonly IInterviewService _interview;
        public InterviewController(IInterviewService interviewService)
        {
            _interview = interviewService;
        }
        // GET: api/<InterviewController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _interview.GetAllAsync();
            return Ok(result);
        }

        // GET api/<InterviewController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var data =  await _interview.GetByIdAsync(id);
          
            return Ok(data);
        }

        // POST api/<InterviewController>
        [HttpPost]
        public async Task<ActionResult> Post(InterviewCreateDto data)
        {
            await _interview.AddAsync(data);
            return Ok();
        }

        // PUT api/<InterviewController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(InterviewUpdateDto data, int id)
        {
            data.Id = id;
            await _interview.UpdateAsync(data);
            return Ok();
        }

        // DELETE api/<InterviewController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _interview.DeleteAsync(id);
            return Ok();
            
        }
    }
}
