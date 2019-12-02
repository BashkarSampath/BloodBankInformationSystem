using BloodBankInformationSystem.Models;
using BloodLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodBankInformationSystem.Services
{
    public interface IBloodStockInfoRepository
    {
        ////stock id
        //Task<bool> stockExists(int stockId);
        ////number of stocks
        //Task<IEnumerable<BloodStock>> GetStocks();
        ////stock id and bank Id
        //Task<BloodBank> GetBankById(int bankId, int stockId);
        ////stockId quantity
        //Task<IEnumerable<BloodStock>> GetNumberOfStock(int stockId, string bloodType);
        //Task AddBloodBank(int stockId, BloodBank bloodBank);
        //void DeletePointOfInterest(BloodBank bloodBank);
        //Task<bool> Save();

        Task Update(BloodStock item);

        Task<bool> Exists(int id);

        Task<IEnumerable<BloodStock>> GetList();

        Task<BloodStock> GetById(int id);

        Task Add(BloodStock item);

        void Delete(BloodStock item);

        Task<bool> Save();

    }
}
