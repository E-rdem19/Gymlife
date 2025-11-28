using Microsoft.AspNetCore.Mvc;
using GymLife.Web.Models;
using GymLife.Web.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GymLife.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly APIService _apiService;

        public HomeController(APIService apiService)
        {
            _apiService = apiService;
        }

        // 🔹 Ana sayfa (Index) için veriler API’den çekiliyor
        public async Task<IActionResult> Index()
        {
            var model = new ModelClass();

            try
            {
                // Home_Panel verilerini API'den çek
                model.Home_Panels = await _apiService.GetAllAsync<Home_Panel>("api/HomeApi");

                // Information_Panel verilerini API'den çek
                model.Information_Panels = await _apiService.GetAllAsync<Information_Panel>("api/InformationApi");
                model.Services = await _apiService.GetAllAsync<Service>("api/ServicesApi");
                model.Package_Tables = await _apiService.GetAllAsync<Package_Table>("api/PackageApi");
                model.Galleries = await _apiService.GetAllAsync<Gallery>("api/GalleryApi");
                model.Instructors = await _apiService.GetAllAsync<Instructor>("api/InstructorApi");
                model.Abouts = await _apiService.GetAllAsync<AboutUS>("api/AboutApi");
                model.Communications = await _apiService.GetAllAsync<Communication>("api/CommunicationApi");
            }
            catch
            {
                // Hata olursa boş listeler gönder (sayfa hata vermesin)
                model.Home_Panels = new List<Home_Panel>();
                model.Information_Panels = new List<Information_Panel>();
                model.Services = new List<Service>();
                model.Package_Tables = new List<Package_Table>();
                model.Galleries = new List<Gallery>();
                model.Instructors = new List<Instructor>();
                model.Abouts = new List<AboutUS>();
                model.Communications = new List<Communication>();
            }

            // ✅ Index.cshtml içinde @model GymLife.Web.Models.ModelClass olmalı
            return View(model);
        }
       
    }
}