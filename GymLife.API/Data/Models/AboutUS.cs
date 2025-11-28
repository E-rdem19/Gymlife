using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GymLife.Web.Models
{
    public class AboutUS
    {
        [Key]
        public int AboutID { get; set; }
        public string? Description { get; set; }
        public string? VideoURL { get; set; }
        public string? Education1 { get; set; }
        public int Puan1 { get; set; }
        public string? Education2 { get; set; }
        public int Puan2 { get; set; }
        public string? Education3 { get; set; }
        public int Puan3 { get; set; }
        public string? Resim { get; set; } 
    }
}