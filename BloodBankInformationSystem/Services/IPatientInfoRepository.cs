using BloodBankInformationSystem.Models;
using BloodLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodBankInformationSystem.Services
{
    public interface IPatientInfoRepository
    {
        Task<bool> Exists(int id);

        Task<IEnumerable<Patient>> GetList();

        Task<Patient> GetById(int id);

        Task Add(Patient item);

        void Delete(Patient item);

        Task<bool> Save();

        Task Update(Patient item);
    }
}
