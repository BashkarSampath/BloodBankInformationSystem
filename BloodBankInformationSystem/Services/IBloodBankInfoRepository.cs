using BloodLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodBankInformationSystem.Services
{
    public interface IBloodBankInfoRepository
    {
        //Task<bool> BloodBankExists(int bankId);
        //Task<IEnumerable<BloodBank>> GetBanks();
        //Task<BloodBank> GetBankById(int bankId, bool includePointsOfInterest);
        //Task<IEnumerable<BloodStock>> GetQuantityById(int bankId, string bloodType);
        //Task AddBloodStock(int bankId, BloodStock bloodStock, int quantity, string bloodType);
        //void DeleteBloodStock(BloodStock bloodStock);
        //Task<bool> Save();
        Task Update(BloodBank item);
        Task<bool> Exists(int id);

        Task<IEnumerable<BloodBank>> GetList();

        Task<BloodBank> GetById(int id);

        Task Add(BloodBank bloodStock);

        void Delete(BloodBank bloodStock);

        Task<bool> Save();
    }
}
