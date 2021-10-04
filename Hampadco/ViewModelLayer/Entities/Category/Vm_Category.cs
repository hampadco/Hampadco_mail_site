using System;
using System.ComponentModel.DataAnnotations;

namespace ViewModelLayer.Entities.Category 
{
    public class Vm_Category 
    {
        [Key]
        public int Id { get; set; }
        public string NameCat { get; set; }
        public int FatherIdCat { get; set; }
        public string Language { get; set; }
        public string FatherName { get; set; }
    }
}