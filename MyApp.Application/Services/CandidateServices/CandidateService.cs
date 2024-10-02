using MyApp.Application.Dtos.CandidateDtos;
using MyApp.Application.Dtos.Interviewdtos;
using MyApp.Data;
using MyApp.Data.Repositories;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;

namespace MyApp.Application.Services.UserServices
{
    public class CandidateService : ICandidateService
    {
        private readonly IGenericRepository<Candidate> _candidate;
        private readonly IGenericRepository<UserDetails> _userDetails;
        private readonly IGenericRepository<Interview> _interview;

        public CandidateService(IGenericRepository<Candidate> candidate, IGenericRepository<UserDetails> userDetail, IGenericRepository<Interview> interview)
        {
            _candidate = candidate;
            _userDetails = userDetail;
            _interview = interview;
        }

        public async Task<OperationHandler<CreateUpdateCandidateDto>> AddAsync(CreateUpdateCandidateDto entity)
        {
            try
            {
                //Candidate 
                Candidate candidate = new Candidate();
                candidate.Name = entity.Name;
                candidate.PassportNumber = entity.PassportNumber;
                candidate.Address = entity.Address;
                candidate.DOB = entity.DOB;
                candidate.IsRejected = false;
                candidate.LastInterviewDate = null;
                candidate.CreatedDate = DateTime.Now;
                candidate.UpdatedDate = DateTime.Now;
                candidate.IsDeleted = false;

                await _candidate.AddAsync(candidate);

                //User and login details
                UserDetails userDetails = new UserDetails();
                userDetails.Email = entity.Email;
                userDetails.PasswordHash = entity.PasswordHash;
                userDetails.CandidateId = candidate.Id;
                userDetails.RoleId = entity.RoleId;
                userDetails.IsDeleted = false;
                userDetails.CreatedDate = DateTime.Now;
                userDetails.UpdatedDate = DateTime.Now;
                await _userDetails.AddAsync(userDetails);

 

                return OperationHandler<CreateUpdateCandidateDto>.Success(null,"Candidate created successfully!");


            }
            catch
            {

                return OperationHandler<CreateUpdateCandidateDto>.Error(null);
            }

        }


        public async Task<OperationHandler<Boolean>> DeleteAsync(int CandidateId)
        {
            var entity = await _candidate.GetByIdAsync(CandidateId);
            //if(entity !=null)
            //{
            //    var entityDetails = _userDetails.GetByIdAsync()
            //}

            return OperationHandler<Boolean>.Success(true);
        }

        public async Task<OperationHandler<IEnumerable<CandidateViewDto>>> GetAllAsync()
        {
            //User iqueryable instead of Ienumerable---?d
            var candidates = await _candidate.GetAllAsync();
            var userDetail = await _userDetails.GetAllAsync();
            var interview = await _interview.GetAllAsync();


            var data = (from c in candidates
                        join d in userDetail on c.Id equals d.CandidateId into dList
                        from dData in dList.DefaultIfEmpty()



                        select new CandidateViewDto()
                        {
                            Address = c.Address,
                            CreatedDate = c.CreatedDate,
                            Email = dData.Email,
                            CandidateId = c.Id,
                            Id = c.Id,
                            IsRejected = c.IsRejected,
                            LastInterviewDate = c.LastInterviewDate,
                            Name = c.Name,
                            PassportNumber = c.PassportNumber,
                            DOB = c.DOB,
                            Interviews = (from i in interview
                                          where i.CandidateId == c.Id
                                          select new InterviewGetDto()
                                          {
                                              Id = i.Id,
                                              CandidateId = i.CandidateId,
                                              CreatedDate = i.CreatedDate,
                                              Feedback = i.Feedback,
                                              InterviewDate = i.InterviewDate,
                                              PanelistId = i.PanelistId,
                                              Score = i.Score,
                                              UpdatedDate = i.UpdatedDate,
                                              IsDeleted = i.IsDeleted,

                                          }).ToList()


                        }

                          ).ToList();

            var result = OperationHandler<IEnumerable<CandidateViewDto>>.Success(data);
            return result;

        }

        public async Task<OperationHandler<CandidateViewDto>> GetByIdAsync(int id)
        {


            var result = OperationHandler<CandidateViewDto>.Success(null);
            return result;


        }

        public async Task<OperationHandler<CreateUpdateCandidateDto>> UpdateAsync(CreateUpdateCandidateDto entity)
        {

            var candidate = await _candidate.GetByIdAsync(entity.Id);

            var result = OperationHandler<CreateUpdateCandidateDto>.Success(null);
            return result;
        }
    }
}
