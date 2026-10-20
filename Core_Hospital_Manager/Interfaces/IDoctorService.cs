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
        Task<List<Doctor>> GetAllAsync();
        Task<Doctor?> GetByIdAsync(int id);
        Task CreateAsync(Doctor hospital);
        Task UpdateAsync(Doctor hospital, List<int> patientIds);
        Task DeleteAsync(int id);
    }
}
