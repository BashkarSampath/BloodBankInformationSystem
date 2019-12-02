using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BloodBankInformationSystem.Models
{
    public class BloodBankCreateDto
    {
        public int Id { get; set; }
        public string bloodBankName { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string phone { get; set; }
        public string website { get; set; }
        public string email { get; set; }

    }
}
