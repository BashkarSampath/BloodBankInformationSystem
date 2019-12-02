using BloodLibrary.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodBankInformationSystem.Services
{
    public class BloodStockInfoRepository : IBloodStockInfoRepository
    {
        private BloodDBcontext _context;

        public BloodStockInfoRepository(BloodDBcontext context)
        {
            _context = context;
        }

        public async Task<bool> Exists(int id)
        {
            return await _context.Stock.AnyAsync<BloodStock>(b => b.Id == id);
        }

        public async Task<IEnumerable<BloodStock>> GetList()
        {
            var result = _context.Stock.OrderBy(c => c.bloodType);
            return await result.ToListAsync();
        }

        public async Task<BloodStock> GetById(int id)
        {
            return await _context.Stock.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task Add(BloodStock item)
        {
            await _context.Stock.AddAsync(item);
        }

        public void Delete(BloodStock item)
        {
            _context.Stock.Remove(item);
        }

        public async Task Update(BloodStock item)
        {

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Save()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        
    }
}
