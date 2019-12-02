using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloodBankInformationSystem.Models.BloodStock
{
    public class BloodStockUpdateDto
    {
        public int Id { get; set; }
        public string bloodType { get; set; }
        public int bloodBankId { get; set; }
        public int quantity { get; set; }
        public DateTime bastBefore { get; set; }
        public string status { get; set; }
    }
}
