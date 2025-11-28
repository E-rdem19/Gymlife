using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GymLife.Web.Models
{
    public class Services
    {
        [Key]
        public int ServiceID { get; set; }
        public string? ServiceName { get; set; }
        public string? Description { get; set; }
        public string? Resim { get; set; }
        public int EgitmenID { get; set; }
        public int BranchID { get; set; }
        public string? longDescription { get; set; }
    }
}