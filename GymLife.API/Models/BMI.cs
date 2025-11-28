using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GymLife.API.Models
{
    public class BMI
    {
        [Key]
        public int BMI_ID { get; set; }
        public int UserID { get; set; }
        public string? VKI { get; set; }
        public string? Weight_Status { get; set; }
        public string? Description { get; set; }
    }
}