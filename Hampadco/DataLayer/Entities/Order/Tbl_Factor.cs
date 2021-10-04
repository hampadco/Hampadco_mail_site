using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;

namespace DataLayer.Entities.Order
{
    public class Tbl_Factor 
    {
        [Key]
        public int Id { get; set; }
        public string Id_Order { get; set; }
        public int Product_Id { get; set; }
        public string Product_Name { get; set; }
        public int Product_Count { get; set; }
        public int product_Price { get; set; }
        public int Total_sum { get; set; }
        public int RFactor { get; set; }
    }
}