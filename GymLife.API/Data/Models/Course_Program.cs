using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GymLife.Web.Models
{
    public class Course_Program
    {
        [Key]
        public int Course_ProgramID { get; set; }
        public string? Name { get; set; }
        public int EgitmenID { get; set; }
        public string? Duration { get; set; }
        public int ServiceID { get; set; }
    }
}