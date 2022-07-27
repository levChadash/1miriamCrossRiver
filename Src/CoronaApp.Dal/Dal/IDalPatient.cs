using CoronaApp.Dal.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoronaApp.Dal;

public interface IDalPatient
{
    Task<List<Patient>> Get();
    Task Post(Patient patient);
}