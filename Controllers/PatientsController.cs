using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EssatoTaskClinicManage.Data;
using EssatoTaskClinicManage.Models;
using System.Linq.Expressions;
using System.Reflection;

namespace EssatoTaskClinicManage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly ClinicContext _context;

        public PatientsController(ClinicContext context)
        {
            _context = context;
        }

        // GET: api/Patients?city=Springfield&zipCode=12345
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patient>>> GetPatients([FromQuery] string? city, [FromQuery] string? zipCode)


        {
            IQueryable<Patient> query = _context.Patients;

            // Apply city filter if provided
            if (!string.IsNullOrEmpty(city))
            {
                query = query.Where(p => p.City.ToLower().Contains(city.ToLower()));
            }

            // Apply zipCode filter if provided
            if (!string.IsNullOrEmpty(zipCode))
            {
                query = query.Where(p => p.ZipCode == zipCode);
            }

            return await query.ToListAsync();
        }




        // PUT: api/Patients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPatient(int id, Patient patient)
        {
            if (id != patient.Id)
            {
                return BadRequest();
            }

            _context.Entry(patient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatientExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Patients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Patient>> PostPatient(Patient patient)
        {
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPatient", new { id = patient.Id }, patient);
        }

        // DELETE: api/Patients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient == null)
            {
                return NotFound();
            }

            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PatientExists(int id)
        {
            return _context.Patients.Any(e => e.Id == id);
        }
    }
}
