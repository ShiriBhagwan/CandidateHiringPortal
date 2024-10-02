using MyApp.Application.Dtos.CandidateDtos;
using MyApp.Data;

namespace MyApp.Application
{
    public interface ICandidateService
    {
        Task<OperationHandler<IEnumerable<CandidateViewDto>>> GetAllAsync();
        Task<OperationHandler<CandidateViewDto>> GetByIdAsync(int id);
        Task<OperationHandler<CandidateCreateDto>> AddAsync(CandidateCreateDto entity);
        Task<OperationHandler<CandidateUpdateDto>> UpdateAsync(CandidateUpdateDto entity);
        Task<OperationHandler<Boolean>> DeleteAsync(int CandidateId);
    }
}
