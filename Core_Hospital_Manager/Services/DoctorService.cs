using Core_Hospital_Manager.Interfaces;
using Data_Hospital_Manager;
using Data_Hospital_Manager.Entities;
using Microsoft.Data.SqlClient;
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
        public async Task CreateAsync(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var doctor = await GetByIdAsync(id);
            if (doctor != null)
            {
                _context.DoctorPatients.RemoveRange(doctor.DoctorPatients);
                _context.Doctors.Remove(doctor);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Doctor>> GetAllAsync(string? search, string? speciality, string? sortOrder)
        {
            var query = _context.Doctors.Include(d => d.Hospital).Where(d => true);
            IQueryable<Doctor> queryable = _context.Doctors.Include(d => d.Hospital);
            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(d => d.FirstName.Contains(search) || d.LastName.Contains(search));
            }
            if (!string.IsNullOrWhiteSpace(speciality))
            {
                query = query.Where(d => d.Specialty.Contains(speciality));
            }
            switch (sortOrder)
            {
                case "name_asc":
                    query = query.OrderBy(d => d.FirstName).ThenBy(d => d.LastName);
                    break;
                case "name_desc":
                    query = query.OrderByDescending(d => d.FirstName).ThenByDescending(d => d.LastName);
                    break;
                case "specialty":
                    query = query.OrderBy(d => d.Specialty).ThenBy(d => d.FirstName);
                    break;
                default:
                    query = query.OrderBy(d => d.FirstName).ThenBy(d => d.LastName);
                    break;
            }
            return await query.ToListAsync();
        }

        public async Task<Doctor?> GetByIdAsync(int id)
        {
            return await _context.Doctors.Include(x => x.Hospital).Include(x => x.DoctorPatients).ThenInclude(x => x.Patient).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Doctor doctor)
        {
            await _context.SaveChangesAsync();
        }
    }
}
