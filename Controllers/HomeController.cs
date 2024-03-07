using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using rubinetti.alessandro._5i.primaWeb.Models;
using System.Security.Cryptography;
using System.Text;

namespace rubinetti.alessandro._5i.primaWeb.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    static List<Prodotti> prodottim = new List<Prodotti>();
    private dbContext db = new dbContext();
    
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
        if (string.IsNullOrEmpty(HttpContext.Session.GetString("Username"))){
            return View("Login");
        }
        return View();
    }

    [HttpGet]
    public IActionResult SignUp()
    {
        if (string.IsNullOrEmpty(HttpContext.Session.GetString("Username")))
        {
            return View();
        }
        return View("Riepilogo", User);
    }
    public IActionResult Login()
    {
        return View();
    }
    public IActionResult Riepilogo()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Riepilogo(Prenotazione p)
    {
        string hash = ComputeSHA256Hash(p.Password!);
        p.Password = hash;
        foreach (var item in db.Prenotaziones)
        {
            if (item.Username == p.Username && item.Password == hash)
            {
                TempData["AlertMessage"] = "User already exists. Please log in.";
                return View("Login");
            }
        }
        db.Prenotaziones.Add(p);
        db.SaveChanges();
        HttpContext.Session.SetString("Username", p.Username!);
        HttpContext.Session.SetString("NomeUtente", p.Nome!);
        HttpContext.Session.SetString("CognomeUtente", p.Cognome!);
        HttpContext.Session.SetString("EmailUtente", p.Email!);
        HttpContext.Session.SetString("NascitaUtente", p.dataNascita.ToString());
        HttpContext.Session.SetString("SessoUtente", p.sesso!);
        HttpContext.Session.SetString("RuoloUtente", p.ruolo!);
        return View(p);
    }
    public IActionResult Purchase(Prodotti p)
    {
        if (string.IsNullOrEmpty(HttpContext.Session.GetString("Username"))){
            return View("Login");
        }
        if(p.Nome != null){
            db.Prodottis.Add(p);
            db.SaveChanges();
        }
        return View();
    }

    public IActionResult Logout()
    {
        HttpContext.Session.SetString("Username", "");
        TempData["Message"] = "You have been successfully logged out.";
        return View("Login");
    }

    
    public IActionResult Cart()
    {
        if (string.IsNullOrEmpty(HttpContext.Session.GetString("Username"))){
            return View("Login");
        }
        return View(db);
    }
    public IActionResult Delete(int i)
    {
        var query = db.Prodottis.Where(c => c.ProdottiId.Equals(i)).ToList();
        foreach (var item in query)
        {
            db.Prodottis.Remove(item);
        }
        db.SaveChanges();
        return View("Cart", db);
    }

    public IActionResult Verifica(Prenotazione p)
    {
        string hash = ComputeSHA256Hash(p.Password!);
        bool userFound = false;
        foreach (var item in db.Prenotaziones)
        {
            if (item.Username == p.Username && item.Password == hash)
            {
                HttpContext.Session.SetString("Username", p.Username!);
                HttpContext.Session.SetString("NomeUtente", item.Nome!);
                HttpContext.Session.SetString("CognomeUtente", item.Cognome!);
                HttpContext.Session.SetString("EmailUtente", item.Email!);
                HttpContext.Session.SetString("NascitaUtente", item.dataNascita.ToString());
                HttpContext.Session.SetString("SessoUtente", item.sesso!);
                HttpContext.Session.SetString("RuoloUtente", item.ruolo!);
                userFound = true;
                break;
            }
        }
        if (!userFound)
        {
            TempData["AlertMessage"] = "Invalid username or password. Please try again.";
            return RedirectToAction("Login");
        }
        return RedirectToAction("Index");
    }

    private string ComputeSHA256Hash(string input)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder builder = new StringBuilder();
            foreach (byte b in bytes)
            {
                builder.Append(b.ToString("x2"));
            }
            return builder.ToString();
        }
    }
    

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
