using System;
using System.IO;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace ViewModelLayer.Entities.Agency 
{
    public class Vm_Agency 
    {
        [Key]
        public int Id { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string NamePerson { get; set; }
        public string Tel { get; set; }
        public string Officetel { get; set; }
        public string Location { get; set; }
        public string Descreption { get; set; }
        public string Language { get; set; }
        public string Address { get; set; }
        public IFormFile img { get; set; }
    }
}