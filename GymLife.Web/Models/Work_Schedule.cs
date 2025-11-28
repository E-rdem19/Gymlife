using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GymLife.Web.Models
{
    public class Work_Schedule
    {
        [Key]
        public int WorkID { get; set; }
        public DateTime date { get; set; }
        public string? Start_Hour { get; set; }
        public string? End_Hour { get; set; }
        public int BranchID { get; set; }

    }
}