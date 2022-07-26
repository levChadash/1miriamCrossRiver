﻿using CoronaApp.Dal.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoronaApp.Dal;

public interface IDalPatient
{
    Task<List<Patient>> GetAllPatients();
    Task<string> AddPatient(Patient patient);
}