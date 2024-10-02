using MyApp.Data;

namespace MyApp.Application
{
    public class UserDetailGetDto
    {
        public int UserDetailId { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public int RoleId { get; set; }  // Roles: Candidate, Panellist, HR, Manager, Recruiter
        public PanelistType PanellistType { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public bool IsDeleted { get; set; } //consider remove this
    }
}
