using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyApp.Data
{
    public class UserDetails
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; } // once strore password wothout hashing
        public int RoleId { get; set; } // Roles: Candidate, Panellist, HR, Manager, Recruiter
        [ForeignKey("RoleId")]
        public Role Role { get; set; } //1:Candidate, 2:Manager, 3:panellist1, 4,Panellist2

        public int CandidateId { get; set; }
        [ForeignKey("CandidateId")]
        public Candidate Candidate { get; set; }
        public PanelistType PanellistType { get; set; } 
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
