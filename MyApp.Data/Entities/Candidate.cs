using System.ComponentModel.DataAnnotations;

namespace MyApp.Data
{
    public class Candidate
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string PassportNumber { get; set; }
        public string Address { get; set; }
        public DateTime DOB { get; set; }
        public DateTime? LastInterviewDate { get; set; } // To check last interview date for 6 months restriction
        public bool IsRejected { get; set; } // Candidate rejection status
        public List<Interview> Interviews { get; set; } // Navigation property to interviews
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
