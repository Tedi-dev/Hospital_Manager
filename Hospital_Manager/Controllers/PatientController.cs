using Data_Hospital_Manager;
using Data_Hospital_Manager.Entities;
<<<<<<< HEAD
using Hospital_Manager.ViewModels.Parent;
=======
using Hospital_Manager.ViewModels.Doctor;
>>>>>>> 5fd0922e6384c5f943a3eea8c1594797bc7638f8
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Manager.Controllers
{
    public class PatientController : Controller
    {
        private readonly HospitalDbContext _context;
<<<<<<< HEAD
        public PatientController(HospitalDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var patients = await _context.Patients.Include(patients => patients.DoctorPatients).ThenInclude(dp => dp.Doctor).ToArrayAsync();
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
            var patient = await _context.Patients.Include(p => p.DoctorPatients).ThenInclude(dp => dp.Doctor).FirstOrDefaultAsync(p => p.Id == id);
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
            var doctors = await _context.Doctors.Select(d => new { d.Id, FullName = d.FirstName + " " + d.LastName }).ToListAsync();
            ViewBag.Doctors = new MultiSelectList(doctors, "Id", "FullName", selectedDoctors);
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
        public async Task<IActionResult> Create(PatientEditViewModel model)
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
                _context.Patients.Add(patient);
                await _context.SaveChangesAsync();
                if (model.DoctorIDs != null && model.DoctorIDs.Count > 0)
                {
                    foreach (var doctorId in model.DoctorIDs)
                    {
                        var doctorPatient = new DoctorPatient
                        {
                            DoctorId = doctorId
                        };
                    }
                    _context.Patients.Add(patient);
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction(nameof(Index));
            }
            await LoadDoctorsAsync(model.DoctorIDs);
            return View(model);
        }
        //Edit Get
        public async Task<IActionResult> Edit(int id)
        {
            var patient = await _context.Patients.Include(p => p.DoctorPatients).ThenInclude(dp => dp.Doctor).FirstOrDefaultAsync(p => p.Id == id);
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
                var patient = await _context.Patients.Include(p => p.DoctorPatients).FirstOrDefaultAsync(p => p.Id == id);
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
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            await LoadDoctorsAsync(model.DoctorIDs);
            return View(model);
        }
        //Dalete Get
        public async Task<IActionResult> Delete(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
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
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient == null)
            {
                return NotFound();
            }
            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
=======

        public IActionResult Index()
        {
            return View();
        }
>>>>>>> 5fd0922e6384c5f943a3eea8c1594797bc7638f8
    }
}
