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
    public class BMIController : Controller
    {
        private readonly APIService _apiService;
        public BMIController(APIService apiService)
        {
            _apiService = apiService;
        }
        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var model = new ModelClass();
            try
            {
                model.Home_Panels = await _apiService.GetAllAsync<Home_Panel>("api/HomeApi");
                model.Communications = await _apiService.GetAllAsync<Communication>("api/CommunicationApi");
            }
            catch
            {
                model.Home_Panels = new List<Home_Panel>();
                model.Communications = new List<Communication>();
            }
            return View("BMIMain", model);
        }
    }
}