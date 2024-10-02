using System.ComponentModel.DataAnnotations;

namespace MyApp.Data
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } 
        public DateTime CreatedDate { get; set; }  
        public DateTime UpdatedDate { get; set; } 
        public bool IsDeleted { get; set; }  

    }
}
