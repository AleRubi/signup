using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using rubinetti.alessandro._5i.primaWeb.Models;

namespace rubinetti.alessandro._5i.primaWeb.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    static List<Prodotti> prodottis = new List<Prodotti>();
    static new Prenotazione? User;
    
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [HttpGet]
    public IActionResult SignUp()
    {
        if (User != null)
        {
            return Riepilogo(User);
        }
        return View();
    }

    [HttpPost]
    public IActionResult Riepilogo(Prenotazione p)
    {
        User = p;
        return View(p);
    }
    public IActionResult Purchase()
    {
        return View();
    }
    public IActionResult Logout()
    {
        User = null;
        return View();
    }

    [HttpPost]
    public IActionResult Cart(Prodotti p)
    {
        prodottis.Add(p);
        return View(prodottis);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
