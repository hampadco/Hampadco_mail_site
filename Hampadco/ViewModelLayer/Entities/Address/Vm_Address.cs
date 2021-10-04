using System;
using System.ComponentModel.DataAnnotations;

namespace ViewModelLayer.Entities.Address 
{
    public class Vm_Address
    {
        [Key]
        public int Id { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Location { get; set; }
        public string Tel1 { get; set; }
        public string Tel2 { get; set; }
        public string Officetel1 { get; set; }
        public string Officetel2 { get; set; }
        public string Language { get; set; }
    }
}