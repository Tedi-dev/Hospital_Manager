using Core_Hospital_Manager.Interfaces;
using Core_Hospital_Manager.Services;
using Data_Hospital_Manager;
using Data_Hospital_Manager.Entities;
using Hospital_Manager.ViewModels.Parent;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Manager.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientService _PService;
        private readonly IDoctorService _DService;
        public PatientController(IPatientService ps, IDoctorService ds)
        {
            _DService = ds;
            _PService = ps;
        }
        public async Task<IActionResult> Index()
        {
            var patients = await _PService.GetAllAsync();
            var model = new List<PatientIndexViewModel>();
            foreach (var patient in patients)
            {
                model.Add(new PatientIndexViewModel
                {
                    Id = patient.Id,
                    FirstName = patient.FirstName,
                    LastName = patient.LastName,
                    Email = patient.Email,
                    PhoneNumber = patient.PhoneNumber,
                    DoctorName = string.Join(", ", patient.DoctorPatients.Select(dp => dp.Doctor.FirstName + " " + dp.Doctor.LastName))
                });
            }
            return View(model);
        }
        public async Task<IActionResult> Details(int id)
        {
            var patient = await _PService.GetByIdAsync(id);
            if (patient == null)
            {
                return NotFound();
            }
            var model = new PatientDetailsViewModel
            {
                Id = patient.Id,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                Email = patient.Email,
                PhoneNumber = patient.PhoneNumber,
                DoctorName = string.Join(", ", patient.DoctorPatients.Select(dp => dp.Doctor.FirstName + " " + dp.Doctor.LastName))
            };
            return View(model);
        }
        //Laoad Doctors
        private async Task LoadDoctorsAsync(List<int> selectedDoctors = null)
        {
            var doctors = await _DService.GetAllAsync();
            var newDoctors = doctors.Select(d => new { d.Id, FullName = d.FirstName + " " + d.LastName });
            ViewBag.Doctors = new MultiSelectList(newDoctors, "Id", "FullName", selectedDoctors);
        }
        //Create Get
        public async Task<IActionResult> Create()
        {
            await LoadDoctorsAsync();
            return View();
        }
        //Create Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PatientCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var patient = new Patient
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber
                };
                if (model.DoctorIDs != null && model.DoctorIDs.Count > 0)
                {
                    foreach (var doctorId in model.DoctorIDs)
                    {
                        var doctorPatient = new DoctorPatient
                        {
                            DoctorId = doctorId,
                            PatientId = patient.Id
                        };
                        patient.DoctorPatients.Add(doctorPatient);
                    }
                }
                await _PService.CreateAsync(patient);
                return RedirectToAction(nameof(Index));
            }
            await LoadDoctorsAsync(model.DoctorIDs);
            return View(model);
        }
        //Edit Get
        public async Task<IActionResult> Edit(int id)
        {
            var patient = await _PService.GetByIdAsync(id);
            if (patient == null)
            {
                return NotFound();
            }
            var model = new PatientEditViewModel
            {
                Id = patient.Id,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                Email = patient.Email,
                PhoneNumber = patient.PhoneNumber,
                DoctorIDs = patient.DoctorPatients.Select(dp => dp.DoctorId).ToList()
            };
            await LoadDoctorsAsync(model.DoctorIDs);
            return View(model);
        }
        //Edit Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PatientEditViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                var patient = await _PService.GetByIdAsync(id);
                if (patient == null)
                {
                    return NotFound();
                }
                patient.FirstName = model.FirstName;
                patient.LastName = model.LastName;
                patient.Email = model.Email;
                patient.PhoneNumber = model.PhoneNumber;
                // Update DoctorPatients
                patient.DoctorPatients.Clear();
                foreach (var doctorId in model.DoctorIDs)
                {
                    patient.DoctorPatients.Add(new DoctorPatient { DoctorId = doctorId, PatientId = patient.Id });
                }
                await _PService.UpdateAsync(patient, model.DoctorIDs);
                return RedirectToAction(nameof(Index));
            }
            await LoadDoctorsAsync(model.DoctorIDs);
            return View(model);
        }
        //Dalete Get
        public async Task<IActionResult> Delete(int id)
        {
            var patient = await _PService.GetByIdAsync(id);
            if (patient == null)
            {
                return NotFound();
            }
            var model = new PatientDeleteViewModel
            {
                Id = patient.Id,
                FirstName = patient.FirstName,
                LastName = patient.LastName
            };
            return View(model);
        }
        //Delete Post
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _PService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
