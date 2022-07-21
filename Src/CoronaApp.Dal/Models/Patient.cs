using System.ComponentModel.DataAnnotations;

namespace CoronaApp.Dal.Models
{
    public class Patient
    {
        [Key]
        [Required]
        [MaxLength(9)]
        public string Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
}