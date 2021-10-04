using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Http;

namespace ViewModelLayer.Entities.Gallery
{
    public class Vm_Gallery
    {
        [Key]
        public int Id { get; set; }
        public string TitleGal { get; set; }
        public string PathImage { get; set; }
        public List<IFormFile> upload_imgs { get; set; }
        public IFormFile img { get; set; }
        public string Language { get; set; }
    }
}