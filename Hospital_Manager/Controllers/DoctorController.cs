using Core_Hospital_Manager.Interfaces;
using Core_Hospital_Manager.Services;
using Data_Hospital_Manager;
using Data_Hospital_Manager.Entities;
using Hospital_Manager.ViewModels.Doctor;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Manager.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IDoctorService _DService;
        private readonly IHospitalService _HService;

        public DoctorController(IDoctorService ds, IHospitalService hs)
        {
            _DService = ds;
            _HService = hs;
        }
        private async void UpdateViewBagAsync()
        {
            ViewBag.Hospitals = new SelectList(
            await _HService.GetAllAsync(),
             "Id",
            "Name");
        }

        public async Task<IActionResult> Index()
        {
            var doctors = await _DService.GetAllAsync();

            var model = new List<DoctorIndexViewModel>();

            foreach (var doctor in doctors)
            {
                model.Add(new DoctorIndexViewModel
                {
                    Id = doctor.Id,
                    FirstName = doctor.FirstName,
                    LastName = doctor.LastName,
                    Specialty = doctor.Specialty,
                    HospitalName = doctor.Hospital.Name
                });
            }

            return View(model);
        }

        public async Task<IActionResult> Details(int id)
        {
            var doctor = await _DService.GetByIdAsync(id);

            if (doctor == null)
            {
                return NotFound();
            }

            var model = new DoctorDetailsViewModel
            {
                Id = doctor.Id,
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                Specialty = doctor.Specialty,
                Email = doctor.Email,
                PhoneNumber = doctor.PhoneNumber,
                HospitalName = doctor.Hospital.Name,
                Patients = doctor.DoctorPatients.Select(dp => $"{dp.Patient.FirstName} {dp.Patient.LastName}").ToList()
            };

            return View(model);
        }

        public async Task<IActionResult> Create()
        {
            UpdateViewBagAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(DoctorCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var doctor = new Doctor
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Specialty = model.Specialty,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    HospitalId = model.HospitalId
                };

                await _DService.CreateAsync(doctor);

                return RedirectToAction(nameof(Index));
            }
            UpdateViewBagAsync();

            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var doctor = await _DService.GetByIdAsync(id);

            if (doctor == null)
            {
                return NotFound();
            }

            var model = new DoctorEditViewModel
            {
                Id = doctor.Id,
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                Specialty = doctor.Specialty,
                Email = doctor.Email,
                PhoneNumber = doctor.PhoneNumber,
                HospitalId = doctor.HospitalId
            };

            UpdateViewBagAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, DoctorEditViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var doctor = await _DService.GetByIdAsync(id);

                if (doctor == null)
                {
                    return NotFound();
                }

                doctor.FirstName = model.FirstName;
                doctor.LastName = model.LastName;
                doctor.Specialty = model.Specialty;
                doctor.Email = model.Email;
                doctor.PhoneNumber = model.PhoneNumber;
                doctor.HospitalId = model.HospitalId;

                return RedirectToAction(nameof(Index));
            }

            UpdateViewBagAsync();

            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var doctor = await _DService.GetByIdAsync(id);

            if (doctor == null)
            {
                return NotFound();
            }

            var model = new DoctorDeleteViewModel
            {
                Id = doctor.Id,
                FirstName = doctor.FirstName,
                LastName = doctor.LastName
            };

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _DService.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> GetFiltered(string? search, string? specialty, string? sortOrder)
        {
            var doctors = await _DService.GetAllAsync(search, specialty, sortOrder);
            var result = doctors.Select(d => new
            {
                id = d.Id,
                firstName = d.FirstName,
                lastName = d.LastName,
                specialty = d.Specialty,
                hospitalName = d.Hospital.Name
            }).ToList();
            return Json(result);
        }
    }
}

