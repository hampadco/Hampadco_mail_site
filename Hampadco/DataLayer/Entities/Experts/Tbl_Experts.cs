using System;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Entities.Experts 
{
    public class Tbl_Experts
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
    }
}