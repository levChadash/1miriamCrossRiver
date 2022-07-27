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
    public async Task<List<Patient>> Get()
    {
        return await dal.Get();
    }
    public async Task Post(Patient patient)
    {
        await dal.Post(patient);
    }
}
