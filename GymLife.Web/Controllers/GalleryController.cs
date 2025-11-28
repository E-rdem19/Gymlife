using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using GymLife.Web.Models;
using GymLife.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GymLife.Web.Controllers
{
    [Route("[controller]")]
    public class GalleryController : Controller
    {
        private readonly APIService _apiService;
        public GalleryController(APIService apiService)
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
                model.Galleries = await _apiService.GetAllAsync<Gallery>("api/GalleryApi");
                model.Communications = await _apiService.GetAllAsync<Communication>("api/CommunicationApi");
            }
            catch 
            {
                model.Home_Panels = new List<Home_Panel>();
                model.Galleries = new List<Gallery>();
                model.Communications = new List<Communication>();
            }
            return View("GalleryMain",model);
        }

        [HttpGet("GalleryPartial")]
        public async Task<IActionResult> GalleryPartial()
        {
            var galleries = await _apiService.GetAllAsync<Gallery>("api/GalleryApi");
            return PartialView("_GalleryPartial", galleries);
        }
        [HttpGet("GalleryDetailsPartial")]
        public async Task<IActionResult> GalleryDetailsPartial()
        {
            var galleryDetails = await _apiService.GetAllAsync<Gallery>("api/GalleryApi");
            return PartialView("_GalleryDetailsPartial", galleryDetails);
        }
    }
}