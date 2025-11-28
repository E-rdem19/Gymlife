using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GymLife.Web.Models
{
    public class Home_Panel
    {
        [Key]
        public int HomeID { get; set; }
        public string? Resim { get; set; }
        public string? Mesaj { get; set; }
    }
}