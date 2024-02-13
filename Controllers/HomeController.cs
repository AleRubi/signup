using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using rubinetti.alessandro._5i.primaWeb.Models;

namespace rubinetti.alessandro._5i.primaWeb.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    static List<Prodotti> prodottid = new List<Prodotti>();
    private dbContext db = new dbContext();
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
        if (string.IsNullOrEmpty(HttpContext.Session.GetString("NomeUtente"))){
            return View("SignUp");
        }
        return View();
    }

    [HttpGet]
    public IActionResult SignUp()
    {
        if (string.IsNullOrEmpty(HttpContext.Session.GetString("NomeUtente")))
        {
            return View();
        }
        return View("Riepilogo", User);
    }

    [HttpPost]
    public IActionResult Riepilogo(Prenotazione p)
    {
        /*db.Prenotaziones.Add(p);
        db.SaveChanges();*/
        HttpContext.Session.SetString("NomeUtente", p.Nome);
        HttpContext.Session.SetString("CognomeUtente", p.Cognome);
        HttpContext.Session.SetString("EmailUtente", p.Email);
        HttpContext.Session.SetString("NascitaUtente", p.dataNascita.ToString());
        HttpContext.Session.SetString("SessoUtente", p.sesso);
        HttpContext.Session.SetString("RuoloUtente", p.ruolo);
        User = p;
        return View(p);
    }
    public IActionResult Purchase(Prodotti p)
    {
        if (string.IsNullOrEmpty(HttpContext.Session.GetString("NomeUtente"))){
            return View("SignUp");
        }
        prodottid.Add(p);
        db.Prodottis.Add(p);
        db.SaveChanges();
        return View();
    }

    public IActionResult Logout()
    {
        HttpContext.Session.SetString("NomeUtente", "");
        User = null;
        return View();
    }

    
    public IActionResult Cart()
    {
        if (string.IsNullOrEmpty(HttpContext.Session.GetString("NomeUtente"))){
            return View("SignUp");
        }
        return View(db);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
