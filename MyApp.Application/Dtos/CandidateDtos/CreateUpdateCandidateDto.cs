﻿using MyApp.Data;

namespace MyApp.Application.Dtos.CandidateDtos
{
    public class CreateUpdateCandidateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PassportNumber { get; set; }
        public string Address { get; set; }
        public DateTime DOB { get; set; }
        public DateTime? LastInterviewDate { get; set; } // To check last interview date for 6 months restriction
        public bool IsRejected { get; set; } // Candidate rejection status


        //UserDetails
        public int UserDetailId { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public int RoleId { get; set; }  // Roles: Candidate, Panellist, HR, Manager, Recruiter
        public int CandidateId { get; set; }
        public PanelistType PanellistType { get; set; }

        //Common
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }

    }
}
