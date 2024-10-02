using MyApp.Data;

namespace MyApp.Application.Dtos.CandidateDtos
{
    public class CandidateUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PassportNumber { get; set; }
        public string Address { get; set; }
        public DateTime DOB { get; set; }
        public DateTime? LastInterviewDate { get; set; } // To check last interview date for 6 months restriction
        public bool IsRejected { get; set; } // Candidate rejection status


        //UserDetails
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public int RoleId { get; set; } = Convert.ToInt32(PanelistType.Candidate);// Roles: Candidate, Panellist, HR, Manager, Recruiter
        public PanelistType PanellistType { get; set; } = PanelistType.Candidate;

        //Common
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
