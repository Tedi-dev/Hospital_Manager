using Data_Hospital_Manager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Hospital_Manager.Interfaces
{
    public interface IHospitalService
    {
        Task<List<Hospital>> GetAllAsync(string? search = null, int? minBeds = null, string? sortOrder = null);
        Task<Hospital?> GetByIdAsync(int id);
        // Do not return results
        Task CreateAsync(Hospital hospital);
        Task UpdateAsync(Hospital hospital);
        Task DeleteAsync(int id);
    }
}
