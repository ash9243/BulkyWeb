using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BulkyWeb.Models;

namespace BulkyWeb.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly List<LoginModel> _userCredentials;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
        _userCredentials = new List<LoginModel>();
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Login()
    {
        return View();
    }

    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public IActionResult HandleForm(LoginModel data)
    {
        _userCredentials.Add(data);
        Console.WriteLine($"data {data}");
        ModelPrinter.PrintModel(data);
        Console.WriteLine($"_userCredentials {_userCredentials}");

        foreach(LoginModel item in _userCredentials){
            ModelPrinter.PrintModel(item);
        }

        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

