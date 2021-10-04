using System;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Entities.Agency 
{
    public class Tbl_Agency 
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
    }
}