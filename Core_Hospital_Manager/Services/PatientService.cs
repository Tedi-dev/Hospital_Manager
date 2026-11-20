using Core_Hospital_Manager.Interfaces;
using Data_Hospital_Manager;
using Data_Hospital_Manager.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Hospital_Manager.Services
{
    public class PatientService : IPatientService
    {
        private readonly HospitalDbContext _context;
        public PatientService(HospitalDbContext context)
        {
            _context = context;
        }
        public async Task<List<Patient>> GetAllAsync()
        {
            return await _context.Patients.Include(x => x.DoctorPatients).ThenInclude(x => x.Doctor).ToListAsync();
        }
        public async Task<Patient?> GetByIdAsync(int id)
        {
            return await _context.Patients.Include(x => x.DoctorPatients).ThenInclude(x => x.Doctor).FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task CreateAsync(Patient patient)
        {
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Patient patient, List<int> doctorIds)
        {
            patient.DoctorPatients.Clear();
            foreach (var doctorId in doctorIds.Distinct())
            {
                patient.DoctorPatients.Add(new DoctorPatient { DoctorId = doctorId, PatientId = patient.Id });
            }
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var patient = await _context.Patients.Include(x => x.DoctorPatients).ThenInclude(x => x.Doctor).FirstOrDefaultAsync(x => x.Id ==id);
            if (patient != null)
            {
                _context.DoctorPatients.RemoveRange(patient.DoctorPatients);
                _context.Patients.Remove(patient);
                await _context.SaveChangesAsync();
            }
        }
    }
}
