using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymLife.Web.Models
{
    public class BlogDetails
    {
        public string? Title { get; set; }
        public DateTime Date { get; set; }
        public int Like { get; set; }
        public string? ImagePath { get; set; }
        public string? Description { get; set; }
        public string? AD { get; set; }
        public string? Soyad { get; set; }
    }
}