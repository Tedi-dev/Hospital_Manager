using Data_Hospital_Manager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Hospital_Manager.Interfaces
{
    public interface IDoctorService
    {
        Task<List<Doctor>> GetAllAsync(string? search = null, string? speciality = null, string? sortOrder = null);
        Task<Doctor?> GetByIdAsync(int id);
        Task CreateAsync(Doctor doctor);
        Task UpdateAsync(Doctor doctor);
        Task DeleteAsync(int id);
    }
}
