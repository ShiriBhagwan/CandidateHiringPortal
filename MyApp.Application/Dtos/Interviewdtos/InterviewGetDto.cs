using MyApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Dtos.Interviewdtos
{
    public class InterviewGetDto
    {
        public int Id { get; set; }
        public int CandidateId { get; set; }
         public int PanelistId { get; set; } // Reference to Panelist (could be Panellist1, Panellist2, HR)
        //public PanelistType PanelistType { get; set; } // Enum for Panelist type
         public int Score { get; set; } // Score between 1-10
         public string Feedback { get; set; }   //1000 words max
        public DateTime InterviewDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
