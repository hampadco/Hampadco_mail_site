using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;

namespace DataLayer.Entities.Order 
{
    public class Tbl_Order 
    {
        [Key]
        public int Id { get; set; }
        public string Id_user { get; set; }
        public DateTime Date_Order { get; set; }
        public DateTime Date_Send { get; set; }
        public string Pay { get; set; }
        public string State { get; set; }
        public string Address { get; set; }
        public string Post { get; set; }
        public int RFactor { get; set; }
    }
}