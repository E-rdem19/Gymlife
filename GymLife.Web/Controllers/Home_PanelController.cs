using GymLife.Web.Models;
using GymLife.Web.Services;
using Microsoft.AspNetCore.Mvc;

[Route("[controller]")]
public class Home_PanelController : Controller
{
    private readonly APIService _apiService;

    public Home_PanelController(APIService apiService)
    {
        _apiService = apiService;
    }

   
}