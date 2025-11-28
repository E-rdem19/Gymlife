using Microsoft.AspNetCore.Mvc;
using GymLife.Web.Models;
using GymLife.Web.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Dynamic;

namespace GymLife.Web.Controllers
{
    public class AboutController : Controller
    {
        private readonly APIService _apiService;

        public AboutController(APIService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var model = new ModelClass();
            try
            {
                model.Abouts = await _apiService.GetAllAsync<AboutUS>("api/AboutApi");
                model.Home_Panels = await _apiService.GetAllAsync<Home_Panel>("api/HomeApi");
                model.Information_Panels = await _apiService.GetAllAsync<Information_Panel>("api/InformationApi");
                model.Instructors = await _apiService.GetAllAsync<Instructor>("api/InstructorApi");
                model.Contects = await _apiService.GetAllAsync<Contect>("api/ContectApi");
                model.Contacts = await _apiService.GetContactsAsync<Contact>("api/ContectApi/GetContact");
                model.Communications = await _apiService.GetAllAsync<Communication>("api/CommunicationApi");
            }
            catch
            {
                model.Abouts = new List<AboutUS>();
                model.Home_Panels = new List<Home_Panel>();
                model.Information_Panels = new List<Information_Panel>();
                model.Instructors = new List<Instructor>();
                model.Contects = new List<Contect>();
                model.Contacts = new List<Contact>();
                model.Communications = new List<Communication>();
            }
            return View("AboutMain",model); // Burada Views/About/Index.cshtml aranacak
        }

        [HttpGet]
        public async Task<IActionResult> AboutPartial()
        {
            var abouts = await _apiService.GetAllAsync<AboutUS>("api/AboutApi");
            return PartialView("_AboutPartial", abouts);
        }
        [HttpGet("GetContact")]
        public async Task<IActionResult> GetContact()
        {
            var contacts = await _apiService.GetContactsAsync<Contact>("api/ContectApi/GetContact");
            return PartialView("_ContactPartial", contacts);
        }
    }
}