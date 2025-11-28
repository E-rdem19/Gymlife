using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GymLife.Web.Models
{
    public class Contect
    {
        [Key]
        public int ContectID { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Message { get; set; }
        public DateTime Date { get; set; }
    }
}