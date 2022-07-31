using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CoronaApp.Dal.Models
{
    public class Location
    {
        [Key]
       
        public int LocaionId { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime EndDate { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        [StringLength(9)]
        public string PatientId { get; set; }
        [ForeignKey("PatientId")]
        [JsonIgnore]
        public virtual Patient Patient { get; set; }

  
    }
}