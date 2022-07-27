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

        public async Task<List<Patient>> Get()
        {
            List<Patient> lp = await _context.Patients.ToListAsync();
            if (lp == null)
                return null;
            else
            { //return lp
                throw new NotImplementedException();
            }

        }

        public async Task Post(Patient patient)
        {
            await _context.Patients.AddAsync(patient);
            await _context.SaveChangesAsync();
        }
    }

