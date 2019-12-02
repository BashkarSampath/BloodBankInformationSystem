using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodBankInformationSystem.Models.Patient
{
    public class PatientCreateDto
    {
        public int Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int age { get; set; }
        public string gender { get; set; }
        public string bloodGroup { get; set; }
        public string city { get; set; }
        public string phone { get; set; }
    }
}
