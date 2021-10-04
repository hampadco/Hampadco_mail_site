using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace DataLayer.Entities.Logo
{
    public class Tbl_Logo
    {
        [Key]
        public int Id { get; set; }
        public string TitleLogo { get; set; }
        public string ImageLogo { get; set; }
        public string FavIcon { get; set; }             
        public string Language { get; set; }
    }
}