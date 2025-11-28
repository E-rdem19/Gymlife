using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GymLife.API.Models
{
    public class Opinion
    {
        [Key]
        public int OpinionID { get; set; }
        public int UserID { get; set; }
        public string? Message { get; set; }
        public int BranchID { get; set; }
        public DateTime Date { get; set; }
    }
}