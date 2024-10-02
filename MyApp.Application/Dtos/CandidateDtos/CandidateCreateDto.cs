using MyApp.Data;

namespace MyApp.Application
{
    public class CandidateCreateDto
    {
        public string Name { get; set; }
        public string PassportNumber { get; set; }
        public string Address { get; set; }
        public DateTime DOB { get; set; }


        //UserDetails
        public string Email { get; set; }
        public string PasswordHash { get; set; } //once store direct password
        public int RoleId { get; set; } = Convert.ToInt32(PanelistType.Candidate);  // Roles: Candidate, Panellist, HR, Manager, Recruiter
        public PanelistType PanellistType { get; set; } = PanelistType.Candidate;


    }
}
