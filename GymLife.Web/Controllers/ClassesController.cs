using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using GymLife.Web.Models;
using GymLife.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;

[Route("[controller]")]
public class ClassesController : Controller
{
    private readonly APIService aPIService;
    public ClassesController(APIService aPIService)
    {
        this.aPIService = aPIService;
    }

    // /Classes
    [HttpGet("")]
    public async Task<IActionResult> Index(int category=1)
    {
        var model = new ModelClass();
        try
        {
            model.Course_Programs = await aPIService.GetAllAsync<Course_Program>("api/CourseApi");
            model.Abouts = await aPIService.GetAllAsync<AboutUS>("api/AboutApi");
            model.Instructors = await aPIService.GetAllAsync<Instructor>("api/InstructorApi");
            model.Home_Panels = await aPIService.GetAllAsync<Home_Panel>("api/HomeApi");
            model.Communications = await aPIService.GetAllAsync<Communication>("api/CommunicationApi");
            model.BranchCategories = await aPIService.GetBranchCategoryAsync<BranchCategory>("api/BranchApi", category);
            model.Branch = await aPIService.GetAllAsync<Branch>("api/BranchApi");
            model.Programs = await aPIService.GetAllAsync<GymLife.Web.Models.Program>("api/CourseApi/Program");
        }
        catch
        {
            model.Course_Programs = new List<Course_Program>();
            model.Abouts = new List<AboutUS>();
            model.Instructors = new List<Instructor>();
            model.Home_Panels = new List<Home_Panel>();
            model.Communications = new List<Communication>();
            model.BranchCategories = new List<BranchCategory>();
            model.Branch = new List<Branch>();
            model.Programs = new List<GymLife.Web.Models.Program>();
        }
        return View("ClassesMain", model);
    }

    // /Classes/BranchCategoryPartial/1
    [HttpGet("BranchCategoryPartial/{category?}")]
    public async Task<IActionResult> BranchCategoryPartial(int category=1)
    {
        var services = await aPIService.GetBranchCategoryAsync<BranchCategory>("api/BranchApi", category);
        return PartialView("_BranchCategoryPartial", services);
    }

    // /Classes/BranchListPartial
    [HttpGet("BranchListPartial")]
    public async Task<IActionResult> BranchListPartial()
    {
        var services = await aPIService.GetAllAsync<Branch>("api/BranchApi");
        return PartialView("_BranchListPartial", services);
    }
    [HttpGet("GetImage")]
    public async Task<IActionResult> GetImage()
    {
        var images = await aPIService.GetAllAsync<Branch>("api/BranchApi");
        return PartialView("_ImagePartial", images);
    }
    [HttpGet("ProgramPartial/Program")]
    public async Task<IActionResult> ProgramPartial()
    {
        var programs = await aPIService.GetAllAsync<GymLife.Web.Models.Program>("api/CourseApi/Program");
        return PartialView("_ProgramPartial", programs);
    }
}