using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymLife.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace GymLife.Web.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<BMI> BMIs { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Contect> Contects { get; set; }
        public DbSet<Work_Schedule> Work_Schedules { get; set; }
        public DbSet<Opinion> Opinions { get; set; }
        public DbSet<Course_Program> Course_Programs { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Home_Panel> Homes { get; set; }
        public DbSet<AboutUS> Abouts { get; set; }
        public DbSet<Communication> Communications { get; set; }
        public DbSet<Package_Table> Package_Tables { get; set; }
        public DbSet<Information_Panel> Information_Panels { get; set; }
        public DbSet<Gallery> Galleries { get; set; }
        
    }
}