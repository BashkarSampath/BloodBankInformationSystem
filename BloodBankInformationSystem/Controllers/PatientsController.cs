using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BloodLibrary.Entities;
using BloodBankInformationSystem.Services;
using AutoMapper;
using BloodBankInformationSystem.Models.Patient;

namespace BloodBankInformationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientInfoRepository _repository;
        private readonly IMapper _mapper;

        public PatientsController(IPatientInfoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/Patients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patient>>> GetPatient()
        {
            var results = await _repository.GetList();

            return Ok(results);
        }

        // GET: api/Patients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Patient>> GetPatient(int id)
        {
            var results = await _repository.GetById(id);
            var item = _mapper.Map<PatientDto>(results);
            return Ok(item);
        }
        
        // PUT: api/Patients/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPatient(int id, PatientUpdateDto patient)
        {
            if (id != patient.Id)
            {
                return BadRequest();
            }

            try
            {
                var item = _mapper.Map<Patient>(patient);
                await _repository.Update(item);
            }
            catch (DbUpdateConcurrencyException)
            {
                var t = await PatientExists(id);
                if (!t)
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
        [HttpPost]
        public async Task<ActionResult<Patient>> PostPatient(PatientCreateDto patient)
        {
            var item = this._mapper.Map<Patient>(patient);
            await this._repository.Add(item);
            var dto = this._mapper.Map<PatientDto>(item);
            return CreatedAtAction("GetPatient", new { id = dto.Id }, dto);
        }

        // DELETE: api/Patients/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Patient>> DeletePatient(int id)
        {
            var patient = await _repository.GetById(id);
            if (patient == null)
            {
                return NotFound();
            }

            _repository.Delete(patient);

            return patient;
        }

        private async Task<bool> PatientExists(int id)
        {
            return await _repository.Exists(id);
        }
    }
}
