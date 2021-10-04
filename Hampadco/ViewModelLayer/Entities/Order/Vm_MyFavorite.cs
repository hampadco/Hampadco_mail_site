using System;
using System.ComponentModel.DataAnnotations;

namespace ViewModelLayer.Entities.Order
{
    public class Vm_MyFavorite
    {
        [Key]
        public int Id { get; set; }
        public int IdKala { get; set; }
        public string IdUser { get; set; }
    }
}