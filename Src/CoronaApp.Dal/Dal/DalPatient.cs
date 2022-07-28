using CoronaApp.Dal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Dal;

   public class DalPatient : IDalPatient
    {
         private readonly CoronaAppContext _context;
        public DalPatient(CoronaAppContext context)
        {
            _context = context;
        }

        public async Task<List<Patient>> GetAllPatients()
        {
            List<Patient> lp = await _context.Patients.ToListAsync();
            if (lp == null)
                return null;
            else
            {
            return lp;
            }

        }

        public async Task<string> AddPatient(Patient patient)
        {
        try
        {
            await _context.Patients.AddAsync(patient);
            await _context.SaveChangesAsync();
            return patient.Id;
        }
        catch {
            throw new Exception("didnt add patient");
        }

        }
    }

