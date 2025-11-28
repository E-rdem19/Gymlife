using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GymLife.API.Models
{
    public class Information_Panel
    {
        [Key]
        public int InfoID { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Resim { get; set; }
    }
}