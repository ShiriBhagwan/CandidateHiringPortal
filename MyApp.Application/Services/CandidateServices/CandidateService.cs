using MyApp.Application.Dtos.CandidateDtos;
using MyApp.Application.Dtos.Interviewdtos;
using MyApp.Data;
using MyApp.Data.Repositories;

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

        public async Task<OperationHandler<CandidateCreateDto>> AddAsync(CandidateCreateDto entity)
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
                userDetails.RoleId = Convert.ToInt32(PanelistType.Candidate); //
                userDetails.IsDeleted = false;
                userDetails.PanellistType = PanelistType.Candidate;
                userDetails.CreatedDate = DateTime.Now;
                userDetails.UpdatedDate = DateTime.Now;
                await _userDetails.AddAsync(userDetails);



                return OperationHandler<CandidateCreateDto>.Success(null, "Candidate created successfully!");


            }
            catch
            {

                return OperationHandler<CandidateCreateDto>.Error(null);
            }

        }


        public async Task<OperationHandler<Boolean>> DeleteAsync(int CandidateId)
        {
            try
            {

                //candidate details
                var candidate = await _candidate.GetByIdAsync(CandidateId);
                if (candidate == null)
                {
                    return OperationHandler<Boolean>.Error(false, "Not found.");

                }


                //candidate.userDetails
                var uDetails = await _userDetails.GetAllAsync();
                if (uDetails != null)
                {

                    var userDetails = uDetails.FirstOrDefault(x => x.CandidateId == candidate.Id);
                    if (userDetails != null)
                    {
                        await _userDetails.DeleteAsync(userDetails);
                    }
                }



                //candidate.Interveiws details
                var interviews = await _interview.GetAllAsync();
                if (interviews != null)
                {
                    var candInt = interviews.Where(x => x.CandidateId == candidate.Id).ToList();
                    if (candInt != null)
                    {
                        foreach (var x in candInt)
                        {
                            await _interview.DeleteAsync(x);
                        }
                    }
                }

                await _candidate.DeleteAsync(candidate);



                return OperationHandler<Boolean>.Success(true);
            }
            catch
            {
                return OperationHandler<Boolean>.Error(false);

            }
        }

        public async Task<OperationHandler<IEnumerable<CandidateViewDto>>> GetAllAsync()
        {
            //User iqueryable instead of Ienumerable---?d
            var candidates = await _candidate.GetAllAsync();
            var interview = await _interview.GetAllAsync();
            var userDetail = await _userDetails.GetAllAsync();


            var data = (from c in candidates
                        join d in userDetail on c.Id equals d.CandidateId into dList
                        from dData in dList.DefaultIfEmpty()



                        select new CandidateViewDto()
                        {
                            Address = c.Address,
                            CreatedDate = c.CreatedDate,
                            Id = c.Id,
                            IsRejected = c.IsRejected,
                            LastInterviewDate = c.LastInterviewDate,
                            Name = c.Name,
                            PassportNumber = c.PassportNumber,
                            DOB = c.DOB,
                            UserDetail = (from ud in userDetail
                                          where ud.CandidateId == c.Id
                                          select new UserDetailGetDto()
                                          {
                                              UserDetailId = ud.Id,
                                              CreatedDate = ud.CreatedDate,
                                              Email = ud.Email,
                                              PasswordHash = ud.PasswordHash,
                                              UpdatedDate = ud.UpdatedDate,
                                              IsDeleted = ud.IsDeleted,

                                          }).FirstOrDefault()!,
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

            //User iqueryable instead of Ienumerable---?d
            var candidates = await _candidate.GetAllAsync();
            var interview = await _interview.GetAllAsync();
            var userDetail = await _userDetails.GetAllAsync();


            var data = (from c in candidates
                        join d in userDetail on c.Id equals d.CandidateId into dList
                        from dData in dList.DefaultIfEmpty()
                        where c.Id == id

                        select new CandidateViewDto()
                        {
                            Address = c.Address,
                            CreatedDate = c.CreatedDate,
                            Id = c.Id,
                            IsRejected = c.IsRejected,
                            LastInterviewDate = c.LastInterviewDate,
                            Name = c.Name,
                            PassportNumber = c.PassportNumber,
                            DOB = c.DOB,
                            UserDetail = (from ud in userDetail
                                          where ud.CandidateId == c.Id
                                          select new UserDetailGetDto()
                                          {
                                              UserDetailId = ud.Id,
                                              CreatedDate = ud.CreatedDate,
                                              Email = ud.Email,
                                              PasswordHash = ud.PasswordHash,
                                              UpdatedDate = ud.UpdatedDate,
                                              IsDeleted = ud.IsDeleted,

                                          }).FirstOrDefault()!,
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

                          ).FirstOrDefault();

            var result = OperationHandler<CandidateViewDto>.Success(data);
            return result;



        }

        public async Task<OperationHandler<CandidateUpdateDto>> UpdateAsync(CandidateUpdateDto entity)
        {

            try
            {
                //Candidate 
                var candidate = await _candidate.GetByIdAsync(entity.Id);
                if (candidate == null)
                {
                    return OperationHandler<CandidateUpdateDto>.Error(null);

                }
                candidate.Name = entity.Name;
                candidate.PassportNumber = entity.PassportNumber;
                candidate.Address = entity.Address;
                candidate.DOB = entity.DOB;
                candidate.IsRejected = false;
                candidate.LastInterviewDate = null;
                candidate.CreatedDate = DateTime.Now;
                candidate.UpdatedDate = DateTime.Now;
                candidate.IsDeleted = false;


                //User and login details

                var uDetails = await _userDetails.GetAllAsync();
                if (uDetails == null)
                {
                    return OperationHandler<CandidateUpdateDto>.Error(null);

                }

                var userDetails = uDetails.FirstOrDefault(x => x.CandidateId == candidate.Id);
                if (userDetails == null)
                {
                    return OperationHandler<CandidateUpdateDto>.Error(null);

                }
                userDetails.Email = entity.Email;
                userDetails.PasswordHash = entity.PasswordHash;
                userDetails.CandidateId = candidate.Id;
                userDetails.RoleId = entity.RoleId;
                userDetails.IsDeleted = false;
                userDetails.PanellistType = PanelistType.Candidate;
                userDetails.CreatedDate = DateTime.Now;
                userDetails.UpdatedDate = DateTime.Now;


                await _userDetails.AddAsync(userDetails);
                await _candidate.AddAsync(candidate);



                return OperationHandler<CandidateUpdateDto>.Success(null);


            }
            catch
            {

                return OperationHandler<CandidateUpdateDto>.Error(null);
            }

        }
    }
}
