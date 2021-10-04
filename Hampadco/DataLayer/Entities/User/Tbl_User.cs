using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;

namespace DataLayer.Entities.Users 
{
    public class Tbl_User 
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string NameFamily { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Post { get; set; }
        public string ProfileImage { get; set; }
        public string Language { get; set; }
        public string Token { get; set; }
        public string NationalCode { get; set; }
        public string Lat { get; set; }
        public string Len { get; set; }
    }
}


