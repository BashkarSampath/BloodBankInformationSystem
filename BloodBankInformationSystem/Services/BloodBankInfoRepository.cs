using BloodLibrary.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodBankInformationSystem.Services
{
    public class BloodBankInfoRepository : IBloodBankInfoRepository
    {
        private BloodDBcontext _context;

        public BloodBankInfoRepository(BloodDBcontext context)
        {
            _context = context;
        }

        public async Task<bool> Exists(int id)
        {
            return await _context.Bank.AnyAsync<BloodBank>(b => b.Id == id);
        }

        public async Task<IEnumerable<BloodBank>> GetList()
        {
            var result = _context.Bank.OrderBy(c => c.bloodBankName);
            return await result.ToListAsync();
        }

        public async Task<BloodBank> GetById(int id)
        {
            return await _context.Bank.FirstOrDefaultAsync(p => p.Id == id);
        }

        //public async Task<IEnumerable<BloodStock>> GetQuantityById(int bankId, string bloodType)
        //{
        //    IQueryable<PointsOfInterest> result = _context.PointsOfInterest.Where(p => p.CityId == cityId && p.Id == pointOfInterestId);
        //    return await result.FirstOrDefaultAsync();
        //}

        public async Task Add(BloodBank item)
        {
            await _context.Bank.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task Update(BloodBank item)
        {

             _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public void Delete(BloodBank item)
        {
            _context.Bank.Remove(item);
             _context.SaveChanges();
        }

        public async Task<bool> Save()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }



        


        

        

        

        

        
    }
}
