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
    public class Information_PanelController : Controller
    {
        private readonly APIService _apiService;
        public Information_PanelController(APIService apiService)
        {
            _apiService = apiService;
        }
        [HttpGet]
        public async Task<IActionResult> InformationPartial()
        {
            var information = await _apiService.GetAllAsync<Information_Panel>("api/InformationApi");
            return PartialView("_Information_PanelPartial", information);
        }
    }
}