using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GymLife.Web.Models
{
    public class Communication
    {
        [Key]
        public int CommunicationID { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Phone1 { get; set; }
        public string? Mail { get; set; }
        public string? Location { get; set; }
        public string? Facebook { get; set; }
        public string? Instagram { get; set; }
        public string? Twitter { get; set; }
        public string? Youtube { get; set; }
    }
}