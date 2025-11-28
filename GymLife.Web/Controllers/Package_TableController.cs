using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using GymLife.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GymLife.Web.Controllers
{
    [Route("[controller]")]
    public class Package_TableController : Controller
    {
        private readonly APIService _apiService;
        public Package_TableController(APIService apiService)
        {
            _apiService = apiService;
        }
        [HttpGet]
        public async Task<IActionResult> Package_TablePartial()
        {
            var packageTables = await _apiService.GetAllAsync<Models.Package_Table>("api/PackageApi");
            return PartialView("_Package_TablePartial", packageTables);
        }
    }
}