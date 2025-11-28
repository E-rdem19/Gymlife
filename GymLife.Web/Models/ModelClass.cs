using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace GymLife.Web.Models
{
    public class ModelClass
    {
        public List<Home_Panel>? Home_Panels { get; set; }
        public List<Information_Panel>? Information_Panels { get; set; }
        public List<Service>? Services { get; set; }
        public List<Package_Table>? Package_Tables { get; set; }
        public List<Gallery>? Galleries { get; set; }
        public List<Instructor>? Instructors { get; set; }
        public List<AboutUS>? Abouts { get; set; }
        public List<Communication>? Communications { get; set; }
        public List<Contect>? Contects { get; set; }
        public List<Contact>? Contacts { get; set; }
       public List<Course_Program>? Course_Programs { get; set; }
       public List<BranchCategory>? BranchCategories { get; set; }
       public List<Branch>? Branch { get; set; }
       public List<Program>? Programs { get; set; }
       public List<Blog>? Blogs { get; set; }
       public List<BlogDetails>? BlogDetails { get; set; }
        
    }
}