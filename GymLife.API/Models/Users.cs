using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GymLife.API.Models
{
    public class Users
    {
        [Key]
        public int KullaniciID { get; set; }
        public string? AD { get; set; }
        public string? Soyad { get; set; }
        public string? Email { get; set; }
        public string? Sifre { get; set; }
        public string? Telefon { get; set; }
        public int PaketID { get; set; }
        public string? Resim { get; set; }
        public int EgitmenID { get; set; }
        public int WorkID { get; set; }
        public int BranchID { get; set; }
        
        
    }
}