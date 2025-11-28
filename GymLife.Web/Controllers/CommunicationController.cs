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
    public class CommunicationController : Controller
    {
        private readonly APIService _apiService;
        public CommunicationController(APIService apiService)
        {
            _apiService = apiService;
        }
        [HttpGet]
        public async Task<IActionResult> CommunicationPartial()
        {
           var communications= await _apiService.GetAllAsync<Communication>("api/CommunicationApi");
           return PartialView("_CommunicationPartial", communications);
        }
    }
}