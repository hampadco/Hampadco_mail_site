using System;
using System.ComponentModel.DataAnnotations;

namespace ViewModelLayer.Entities.Richat
{
    public class Vm_Richat
    {
        [Key]
        public int Id { get; set; }
        public string ScriptChat { get; set; }
        public string Zarinpal { get; set; }
        public string Enemad { get; set; }
        public string Sms { get; set; }
        public string Website { get; set; }
        public string Paternsms { get; set; }
        public string Phone { get; set; }  
    }
}