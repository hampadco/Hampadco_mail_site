using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace ViewModelLayer.Entities.Experts 
{
    public class Vm_Experts
    {
        [Key]
        public int Id { get; set; }
        public string NameEx { get; set; }
        public string ImageEx { get; set; }
        public string TelEx { get; set; }
        public string OfficeTelEx { get; set; }
        public string LocationEx { get; set; }
        public string AboutEx { get; set; }
        public string Language { get; set; }
        public string Address { get; set; }
        public IFormFile img { get; set; }
    }
}