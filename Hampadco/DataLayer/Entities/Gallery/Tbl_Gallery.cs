using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace DataLayer.Entities.Gallery
{
    public class Tbl_Gallery
    {
        [Key]
        public int Id { get; set; }
        public string TitleGal { get; set; }
        public string PathImage { get; set; }
        public string Language { get; set; }
    }
}