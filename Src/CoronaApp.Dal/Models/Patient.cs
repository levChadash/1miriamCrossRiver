using System.ComponentModel.DataAnnotations;

namespace CoronaApp.Dal.Models
{
    public class Patient
    {
        [Key]
        [Required]
     
        [StringLength(9)]
        public string Id { get; set; }
        public string Name { get; set; }
        [Range(0, 120)]
        public int Age { get; set; }
    }
}