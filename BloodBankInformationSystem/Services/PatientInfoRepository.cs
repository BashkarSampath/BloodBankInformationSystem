using BloodLibrary.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodBankInformationSystem.Services
{
    public class PatientInfoRepository : IPatientInfoRepository
    {

        private BloodDBcontext _context;

        public PatientInfoRepository(BloodDBcontext context)
        {
            _context = context;
        }

        public async Task<bool> Exists(int id)
        {
            return await _context.Patient.AnyAsync<Patient>(b => b.Id == id);
        }

        public async Task<IEnumerable<Patient>> GetList()
        {
            var result = _context.Patient.OrderBy(c => c.Id);
            return await result.ToListAsync();
        }

        public async Task<Patient> GetById(int id)
        {
            return await _context.Patient.FirstOrDefaultAsync(p => p.Id == id);
        }

        //public async Task<IEnumerable<BloodStock>> GetQuantityById(int bankId, string bloodType)
        //{
        //    IQueryable<PointsOfInterest> result = _context.PointsOfInterest.Where(p => p.CityId == cityId && p.Id == pointOfInterestId);
        //    return await result.FirstOrDefaultAsync();
        //}
        public async Task Update(Patient item)
        {

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Add(Patient item)
        {
            await _context.Patient.AddAsync(item);
        }

        public void Delete(Patient item)
        {
            _context.Patient.Remove(item);
        }

        public async Task<bool> Save()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
