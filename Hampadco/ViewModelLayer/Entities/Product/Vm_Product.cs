using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Security.AccessControl;
using Microsoft.AspNetCore.Http;

namespace ViewModelLayer.Entities.Product 
{
    public class Vm_Product 
    {
        [Key]
        public int Id { get; set; }
        public string TitleProductPro { get; set; }
        public string ImageMainPro { get; set; }
        public string CategoryIdPro { get; set; }
        public string CategoryChildIdPro { get; set; }
        public int PricePro { get; set; }
        public int Price_Pro { get; set; }
        public string OfferPro { get; set; }
        public string SizePro { get; set; }
        public string ColorPro { get; set; }
        public string BrandPro { get; set; }
        public string TypeCarPro { get; set; }
        public string MaterialPro { get; set; }
        public string TotalPro { get; set; }
        public string DescreptionPro { get; set; }
        public string Language { get; set; }
        public string CatName { get; set; }
        public List<IFormFile> upload_imgs { get; set; }
        public IFormFile mainimg { get; set; }
    }
}