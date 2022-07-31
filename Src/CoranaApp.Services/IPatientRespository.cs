using CoronaApp.Dal.Models;
using CoronaApp.Services.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoronaApp.Services;

public interface IPatientRespository
{
    Task<List<PatientDTO>> GetAllPatients();
    Task<string> AddPatient(Patient patient);
}