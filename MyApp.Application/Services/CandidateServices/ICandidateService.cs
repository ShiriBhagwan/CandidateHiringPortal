using MyApp.Application.Dtos.CandidateDtos;
using MyApp.Data;

namespace MyApp.Application
{
    public interface ICandidateService
    {
        Task<OperationHandler<IEnumerable<CandidateViewDto>>> GetAllAsync();
        Task<OperationHandler<CandidateViewDto>> GetByIdAsync(int id);
        Task<OperationHandler<CreateUpdateCandidateDto>> AddAsync(CreateUpdateCandidateDto entity);
        Task<OperationHandler<CreateUpdateCandidateDto>> UpdateAsync(CreateUpdateCandidateDto entity);
        Task<OperationHandler<Boolean>> DeleteAsync(int CandidateId);
    }
}
