using CoronaApp.Dal;
using CoronaApp.Dal.Models;
using System;
using System.Collections.Generic;
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
    public async Task<List<Patient>> GetAllPatients()
    {
        return await dal.GetAllPatients();
    }
    public async Task<string> AddPatient(Patient patient)
    {
         return await dal.AddPatient(patient);
    }
}
