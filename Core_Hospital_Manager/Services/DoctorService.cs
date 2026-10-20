using Core_Hospital_Manager.Interfaces;
using Data_Hospital_Manager;
using Data_Hospital_Manager.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Hospital_Manager.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly HospitalDbContext _context;
        public DoctorService(HospitalDbContext context)
        {
            _context = context;
        }
        public async Task<List<Doctor>> GetAllAsync()
        {
            return await _context.Doctors.Include(x => x.DoctorPatients).ThenInclude(x => x.Patient).ToListAsync();
        }
        public async Task<Doctor?> GetByIdAsync(int id)
        {
            return await _context.Doctors.Include(x => x.DoctorPatients).ThenInclude(x => x.Patient).FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task CreateAsync(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Doctor doctor, List<int> doctorIds)
        {
            doctor.DoctorPatients.Clear();
            foreach (var doctorId in doctorIds.Distinct())
            {
                doctor.DoctorPatients.Add(new DoctorPatient { DoctorId = doctorId, PatientId = doctor.Id });
            }
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var doctor = await _context.Doctors.Include(x => x.DoctorPatients).ThenInclude(x => x.Patient).FirstOrDefaultAsync(x => x.Id == id);
            if (doctor != null)
            {
                _context.DoctorPatients.RemoveRange(doctor.DoctorPatients);
                _context.Doctors.Remove(doctor);
                await _context.SaveChangesAsync();
            }
        }
    }
}
