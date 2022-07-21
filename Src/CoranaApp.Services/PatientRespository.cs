using CoronaApp.Dal;
using CoronaApp.Dal.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Services
{
    public class PatientRespository : IPatientRespository
    {
        IDalPatient dal;
        public PatientRespository(IDalPatient dal)
        {
            this.dal = dal;
        }
        public async Task<List<Patient>> get()
        {
            return await dal.get();
        }
        public async Task post(Patient patient)
        {
            await dal.post(patient);
        }
    }
}
