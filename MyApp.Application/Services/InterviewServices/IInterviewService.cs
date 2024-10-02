using MyApp.Application.Dtos.Interviewdtos;
using MyApp.Application.Dtos.RoleDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Services.InterviewServices
{
    public interface IInterviewService
    {
        Task<IEnumerable<InterviewGetDto>> GetAllAsync();
        Task<InterviewGetDto> GetByIdAsync(int id);
        Task AddAsync(InterviewCreateDto entity);
        Task UpdateAsync(InterviewUpdateDto entity);
        Task DeleteAsync(int id);
    }
}
