using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BloodLibrary.Entities;
using BloodBankInformationSystem.Models;
using BloodBankInformationSystem.Services;
using AutoMapper;

namespace BloodBankInformationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloodBanksController : ControllerBase
    {
        //private readonly BloodDBcontext _context;
        private readonly IBloodBankInfoRepository _repository;
        private readonly IMapper _mapper;

        public BloodBanksController(IBloodBankInfoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/BloodBanks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BloodBank>>> GetBank()
        {
            var results = await _repository.GetList();

            return Ok(results);
        }

        // GET: api/BloodBanks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BloodBankDto>> GetBloodBank(int id)
        {
            var results = await _repository.GetById(id);
            var item = _mapper.Map<BloodBankDto>(results);
            return Ok(item);
        }

        // PUT: api/BloodBanks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBloodBank(int id, BloodBankDto bloodBank)
        {
            if (id != bloodBank.Id)
            {
                return BadRequest();
            }
            
            try
            {
                var item = _mapper.Map<BloodBank>(bloodBank);
                await _repository.Update(item);
            }
            catch (DbUpdateConcurrencyException)
            {
                var t = await BloodBankExists(id);
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

        // POST: api/BloodBanks
        [HttpPost]
        public async Task<ActionResult<BloodBankDto>> PostBloodBank(BloodBankCreateDto bloodBank)
        {
            var item = this._mapper.Map<BloodBank>(bloodBank);
            await this._repository.Add(item);
            var dto = this._mapper.Map<BloodBankDto>(item);
            return CreatedAtAction("GetBloodBank", new { id = dto.Id }, dto);
        }

        // DELETE: api/BloodBanks/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BloodBank>> DeleteBloodBank(int id)
        {
            var bloodBank = await _repository.GetById(id);
            if (bloodBank == null)
            {
                return NotFound();
            }

            _repository.Delete(bloodBank);
          
            return bloodBank;
        }

        private async Task< bool> BloodBankExists(int id)
        {
            return await _repository.Exists(id);
        }
    }
}
