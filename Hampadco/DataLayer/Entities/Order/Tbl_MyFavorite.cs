using System;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Entities.Order
{
    public class Tbl_MyFavorite
    {
        [Key]
        public int Id { get; set; }
        public int IdKala { get; set; }
        public string IdUser { get; set; }
    }
}