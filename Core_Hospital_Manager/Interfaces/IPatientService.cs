using Data_Hospital_Manager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core_Hospital_Manager.Interfaces
{
    public interface IPatientService
    {
        Task<List<Patient>> GetAllAsync();
        Task<Patient?> GetByIdAsync(int id);
        Task CreateAsync(Patient hospital);
        Task UpdateAsync(Patient hospital, List<int> doctorIds);
        Task DeleteAsync(int id);
    }
}
