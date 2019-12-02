using AutoMapper;
using BloodBankInformationSystem.Models;
using BloodBankInformationSystem.Models.BloodStock;
using BloodBankInformationSystem.Models.Patient;
using BloodLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodBankInformationSystem.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<BloodBank, BloodBankDto>();
            CreateMap<BloodBankDto, BloodBank>();
            
            CreateMap<BloodBankCreateDto, BloodBank>();
            CreateMap<BloodBankUpdateDto, BloodBank>();
            CreateMap<BloodStockCreateDto, BloodStock>();
            CreateMap<BloodStockUpdateDto, BloodStock>();
            CreateMap<PatientCreateDto, Patient>();
            CreateMap<PatientUpdateDto, Patient>();

            CreateMap<BloodStock, BloodStockDto>();
            CreateMap<BloodStockDto, BloodStock>();
                       
            CreateMap<Patient, PatientDto>(); 
            CreateMap<PatientDto, Patient>(); 
        }
    }
}
