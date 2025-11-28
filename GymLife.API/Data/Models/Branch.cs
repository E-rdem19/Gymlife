using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GymLife.Web.Models
{
    public class Branch
    {
        [Key]
        public int BranchID { get; set; }
        public string? BranchName { get; set; }
        public string? Description { get; set; }
    }
}