using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GymLife.API.Models
{
    public class Package_Table
    {
        [Key]
        public int PackageID { get; set; }
        public string? Title { get; set; }
        public int Price { get; set; }
        public int Date { get; set; }
        public string? Property1 { get; set; }
        public string? Property2 { get; set; }
        public string? Property3 { get; set; }
        public string? Property4 { get; set; }
        public string? Property5 { get; set; }
    }
}