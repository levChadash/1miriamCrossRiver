using CoronaApp.Dal;
using CoronaApp.Dal.Models;
using CoronaApp.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Services;

public class PatientRespository : IPatientRespository
{
     private readonly IDalPatient dal;
    public PatientRespository(IDalPatient dal)
    {
        this.dal = dal;
    }
    public async Task<List<PatientDTO>> GetAllPatients()
    {
        List<Patient> patients= await dal.GetAllPatients();
        var PatientsDtoList = new List<PatientDTO>();
        PatientsDtoList = patients.Select(p => new PatientDTO(p.Id, p.Name, DateTime.Now.Year - p.DateOfBirth.Year)).ToList();
        return PatientsDtoList;
    }
    public async Task<string> AddPatient(Patient patient)
    {
         return await dal.AddPatient(patient);
    }
}
