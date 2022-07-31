using System;
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
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
    }
}