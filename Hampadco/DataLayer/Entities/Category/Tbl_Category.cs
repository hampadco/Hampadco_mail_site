using System;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Entities.Category 
{
    public class Tbl_Category 
    {
        [Key]
        public int Id { get; set; }
        public string NameCat { get; set; }
        public int FatherIdCat { get; set; }
        public string Language { get; set; }
    }
}