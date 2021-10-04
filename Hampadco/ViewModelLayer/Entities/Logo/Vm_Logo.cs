using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Http;

namespace ViewModelLayer.Entities.Logo
{
    public class Vm_Logo
    {
        [Key]
        public int Id { get; set; }
        public string TitleLogo { get; set; }
        public string FavIcon { get; set; }             
        public string Language { get; set; }
        public IFormFile ImageLogo { get; set; }
        public IFormFile fav { get; set; }
    }
}