using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using GymLife.Web.Models;
using GymLife.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GymLife.Web.Controllers
{
    [Route("[controller]")]
    public class BlogController : Controller
    {
        private readonly APIService _apiService;
        public BlogController(APIService apiService)
        {
            _apiService = apiService;
        }
        [HttpGet("")]
        public async Task<IActionResult> Index(int category = 1)
        {
            var model = new ModelClass();
            try
            {
                model.Home_Panels = await _apiService.GetAllAsync<Home_Panel>("api/HomeApi");
                model.Blogs = await _apiService.GetAllAsync<Blog>("api/BlogApi");
                model.Communications = await _apiService.GetAllAsync<Communication>("api/CommunicationApi");
                model.Branch = await _apiService.GetAllAsync<Branch>("api/BranchApi");
                model.BlogDetails = await _apiService.GetBlogDetailsAsync<BlogDetails>("api/BlogApi", category);

            }
            catch
            {
                model.Home_Panels = new List<Home_Panel>();
                model.Blogs = new List<Blog>();
                model.Communications = new List<Communication>();
                model.Branch = new List<Branch>();
                model.BlogDetails = new List<BlogDetails>();
            }
            return View("BlogMain", model);
        }
        [HttpGet("BlogDetailsPartial/{category?}")]
        public async Task<IActionResult> BlogDetailsPartial(int category = 2)
        {
            var blogDetails = await _apiService.GetBlogDetailsAsync<BlogDetails>("api/BlogApi", category);
            return PartialView("_BlogDetailsPartial", blogDetails);
        }
        [HttpGet("BlogListPartial")]
        public async Task<IActionResult> BlogListPartial()
        {
            var blogs = await _apiService.GetAllAsync<Blog>("api/BlogApi");
            return PartialView("_BlogListPartial", blogs);
        }
    }
}