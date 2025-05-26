using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PatientRecordCURDWebApp.Data;
using PatientRecordCURDWebApp.Models;

namespace PatientRecordCURDWebApp.Controllers
{
    public class PatientController : Controller
    {
        #region Field and Properties
        private const string _indexMethod = "Index";
        #endregion


        #region Dependency Injection.
        private readonly AppDbContext _context;
        public PatientController(AppDbContext context) 
        {
            _context = context;
        }
        #endregion


        #region Read Operation.
        public async Task<IActionResult> Index()
        {
            IEnumerable<Patient> patients = await _context.Patients.ToListAsync();
            return View(patients);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            Patient? patient = await GetPatientWithMedicalRecordAsync(id);


            if (patient == null)
                return NotFound();

            return View(patient);
        }
        #endregion


        #region Create Operation.
        [HttpGet]
        public IActionResult Create()
        {
            var patient = new Patient
            {
                MedicalRecord = new MedicalRecord()
            };
            return View(patient);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Patient patient)
        {
            if (!ModelState.IsValid)
                return View(patient);
            
            patient.PatientId = Guid.NewGuid(); // Ensure PatientId is set for both entities
            if (patient.MedicalRecord != null)
                patient.MedicalRecord.PatientId = patient.PatientId;

            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();
            SweetAlert("created");
            return RedirectToAction(_indexMethod);
        }
        #endregion
        

        #region Update Operation.
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            Patient? patient = await GetPatientWithMedicalRecordAsync(id);

            if (patient == null)
                return NotFound();

            return View(patient);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Patient patient)
        {
            if (!ModelState.IsValid)
                return View(patient);

            _context.Patients.Update(patient);
            await _context.SaveChangesAsync();
            SweetAlert("Updated");
            return RedirectToAction(_indexMethod);
        }
        #endregion


        #region Delete Operation.
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            Patient? patient = await GetPatientWithMedicalRecordAsync(id);

            if (patient == null)
                return NotFound();

            return View(patient);
        }
        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            Patient? patient = await GetPatientWithMedicalRecordAsync(id);

            if (patient == null)
                return NotFound();

            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();
            SweetAlert("Deleted");
            return RedirectToAction(_indexMethod);
        }
        #endregion


        #region Helper Methods.
        private async Task<Patient?> GetPatientWithMedicalRecordAsync(Guid id)
        {
            return await _context.Patients
                .Include(p => p.MedicalRecord)
                .FirstOrDefaultAsync(p => p.PatientId == id);
        }

        private void SweetAlert(string operation)
        {
            TempData["NotificationType"] = "success";
            TempData["Notification"] = $"Patient {operation} successfully!";
        }
        #endregion
    }
}
