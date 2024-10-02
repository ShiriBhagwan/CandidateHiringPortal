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
    public class InterviewUpdateDto
    {
        public int Id { get; set; }
        public int CandidateId { get; set; }
        public int PanelistId { get; set; } // Reference to Panelist (could be Panellist1, Panellist2, HR)
        [Range(0, 10, ErrorMessage = "The value must between 0 and 10.")]
        public int Score { get; set; } // Score between 1-10
        [StringLength(1000, ErrorMessage = "The feedback field must be less than or equal to 1000 characters.")]
        public string Feedback { get; set; }   //1000 words max
        public DateTime InterviewDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
