using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BloodLibrary.Entities
{
    public partial class BloodStock
    {
        [Key]
        public int Id { get; set; }
        public string bloodType { get; set; }
        public int bloodBankId { get; set; }
        public int quantity { get; set; }
        public DateTime bastBefore { get; set; }
        public string status { get; set; }

    }
}
