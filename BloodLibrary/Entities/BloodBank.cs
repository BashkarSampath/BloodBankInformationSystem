using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BloodLibrary.Entities
{
    public partial class BloodBank
    {
       

        [Key]
        public int Id { get; set; }
        public string bloodBankName { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string phone { get; set; }
        public string website { get; set; }
        public string email { get; set; }
        
    }
}
