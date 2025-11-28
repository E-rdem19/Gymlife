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
    public class InstructorController : Controller
    {
        private readonly APIService _apiService;
        public InstructorController(APIService apiService)
        {
            _apiService = apiService;
        }
        [HttpGet]
        public async Task<IActionResult> InstructorPartial()
        {
            var instructors = await _apiService.GetAllAsync<Instructor>("api/InstructorApi");
            return PartialView("_InstructorPartial", instructors);
        }
    }
}