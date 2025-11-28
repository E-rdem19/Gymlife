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
    public class ServiceController : Controller
    {
        private readonly APIService _apiService;
        public ServiceController(APIService apiService)
        {
            _apiService = apiService;
        }
        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var model = new ModelClass();
            try
            {
                model.Services = await _apiService.GetAllAsync<Service>("api/ServicesApi");
                model.Home_Panels = await _apiService.GetAllAsync<Home_Panel>("api/HomeApi");
                model.Information_Panels = await _apiService.GetAllAsync<Information_Panel>("api/InformationApi");
                model.Communications = await _apiService.GetAllAsync<Communication>("api/CommunicationApi");
                model.Package_Tables = await _apiService.GetAllAsync<Package_Table>("api/PackageApi");
            }
            catch
            {
                model.Services = new List<Service>();
                model.Home_Panels = new List<Home_Panel>();
                model.Information_Panels = new List<Information_Panel>();
                model.Communications = new List<Communication>();
                model.Package_Tables = new List<Package_Table>();
            }
            return View("ServiceMain", model);
        }
        [HttpGet("ServicePartial")]
        public async Task<IActionResult> ServicePartial()
        {
            var services = await _apiService.GetAllAsync<Service>("api/ServicesApi");
            return PartialView("_ServicePartial", services);
        }
        [HttpGet("ServiceDetailPartial")]
        public async Task<IActionResult> ServiceDetailPartial()
        {
            var service = await _apiService.GetAllAsync<Service>("api/ServicesApi");
            return PartialView("_ServiceDetailPartial", service);
        }
    }
}