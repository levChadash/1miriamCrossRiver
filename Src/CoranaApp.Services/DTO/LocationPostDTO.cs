using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Services.DTO
{
    public record LocationPostDTO(string Address ,string City, DateTime StartDate, DateTime EndDate, string PatientId);
}
