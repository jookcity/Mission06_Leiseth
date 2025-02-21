using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission6.Models;

namespace Mission6.Controllers;

public class HomeController : Controller
{
    private MovieContext _context;
    
    public HomeController(MovieContext temp)
    {
        _context = temp;
    }

    public IActionResult Index()
    {
        return View();
    }
    public IActionResult GetToKnowJoel()
    {
        return View();
    } 
    //public IActionResult Privacy()
    //{
    //    return View();
    //}

    // GET: Movie/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Movie/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Movie movie)
    {
        _context.Applications.Add(movie);
        _context.SaveChanges();
        
        if (ModelState.IsValid)
        {
            // TODO: Add database save logic here (e.g., using EF Core)
            return RedirectToAction("Index", "Home");
        }
        return View(movie);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

}