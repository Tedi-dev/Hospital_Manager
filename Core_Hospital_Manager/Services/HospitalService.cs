using Core_Hospital_Manager.Interfaces;
using Data_Hospital_Manager;
using Data_Hospital_Manager.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core_Hospital_Manager.Services
{
    public class HospitalService : IHospitalService
    {
        private readonly HospitalDbContext _context;
        public HospitalService(HospitalDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(Hospital hospital)
        {
            _context.Hospitals.Add(hospital);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var hospital = await _context.Hospitals.FindAsync(id);
            if (hospital != null)
            {
                bool hasDoctors = await _context.Doctors.AnyAsync(d => d.HospitalId == id);
                if (hasDoctors)
                    throw new InvalidOperationException("Cannot delete hospital with associated doctors.");
                hospital.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Hospital>> GetAllAsync(string? search = null, int? minBeds = null, string? sortOrder = null)
        {
            var query = _context.Hospitals.Where(h => !h.IsDeleted);
            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(h => h.Name.Contains(search));
            }
            if (minBeds.HasValue)
            {
                query = query.Where(h => h.BedsCount > minBeds.Value);
            }
            switch (sortOrder)
            {
                case "name":
                    query = query.OrderBy(h => h.Name);
                    break;
                case "beds_asc":
                    query = query.OrderBy(h => h.BedsCount);
                    break;
                case "beds_desc":
                    query = query.OrderByDescending(h => h.BedsCount);
                    break;
                default:
                    query = query.OrderBy(h => h.Name);
                    break;
            }
            return await query.ToListAsync();
        }

        public async Task<Hospital?> GetByIdAsync(int id)
        {
            return await _context.Hospitals.FindAsync(id);
        }

        public async Task UpdateAsync(Hospital hospital)
        {
            await _context.SaveChangesAsync();
        }
    }
}
