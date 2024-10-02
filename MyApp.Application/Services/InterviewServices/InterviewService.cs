using MyApp.Application.Dtos.Interviewdtos;
using MyApp.Data;
using MyApp.Data.Repositories;
using System.Data.Common;

namespace MyApp.Application.Services.InterviewServices
{
    public class InterviewService : IInterviewService
    {
        private readonly IGenericRepository<Interview> _repos;
        public InterviewService(IGenericRepository<Interview> repos)
        {
            _repos = repos;
        }
        public async Task AddAsync(InterviewCreateDto entity)
        {
            //Update exception and validations after CRUD Basic operation completed;

            Interview interview = new Interview()
            {
                CandidateId = entity.CandidateId,
                InterviewDate = entity.InterviewDate,
                PanelistId = entity.PanelistId,
                Score = entity.Score,
                Feedback = entity.Feedback,
                PanelistType = PanelistType.Panellist1, //Update this according to login panellisttype

                CreatedDate = entity.CreatedDate,
                UpdatedDate = entity.UpdatedDate,
                IsDeleted = entity.IsDeleted,
            };
            await _repos.AddAsync(interview);
            return;
        }

        public async Task DeleteAsync(int id)
        {
            //Update ex. handling and validation and return;
            var data = _repos.GetByIdAsync(id);
            if (data != null)
            {
                await _repos.DeleteAsync(data.Result);

            }
            return;

        }

        public async Task<IEnumerable<InterviewGetDto>> GetAllAsync()
        {
            var data = await _repos.GetAllAsync();
            var result = data.Select(x => new InterviewGetDto
            {
                CandidateId = x.CandidateId,
                InterviewDate = x.InterviewDate,
                PanelistId = x.PanelistId,
                Score = x.Score,
                CreatedDate = x.CreatedDate,
                UpdatedDate = x.UpdatedDate,
                IsDeleted = x.IsDeleted,
                Feedback = x.Feedback,
                Id = x.Id
            }).ToList();
            return result;
        }

        public async Task<InterviewGetDto> GetByIdAsync(int id)
        {
            var x = await _repos.GetByIdAsync(id);

            var result = new InterviewGetDto
            {
                CandidateId = x.CandidateId,
                InterviewDate = x.InterviewDate,
                PanelistId = x.PanelistId,
                Score = x.Score,
                CreatedDate = x.CreatedDate,
                UpdatedDate = x.UpdatedDate,
                IsDeleted = x.IsDeleted,
                Feedback = x.Feedback,
                Id = x.Id
            };
            return result;
        }

        public async Task UpdateAsync(InterviewUpdateDto entity)
        {
            var data = await _repos.GetByIdAsync(entity.Id);
            if(data !=null)
            {
                 data.CandidateId = entity.CandidateId;
                data.PanelistId = entity.PanelistId;
                data.UpdatedDate = DateTime.Now;
                data.IsDeleted = entity.IsDeleted;
                data.Feedback = entity.Feedback;
                data.Score = entity.Score;

                await _repos.UpdateAsync(data);
                return;

            }
        }
    }
}
