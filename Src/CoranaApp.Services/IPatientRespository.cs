using CoronaApp.Dal.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoronaApp.Services
{
    public interface IPatientRespository
    {
        Task<List<Patient>> get();
        Task post(Patient patient);
    }
}