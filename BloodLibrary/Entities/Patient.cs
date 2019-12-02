using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BloodLibrary.Entities
{
    public partial class Patient
    {
        [Key]
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
