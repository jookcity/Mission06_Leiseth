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

    // GET: Movie/Create
    public IActionResult Create()
    {
        return View();
    }
    
    // POST: Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Movie movie)
    {
        if (ModelState.IsValid)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return RedirectToAction("MovieList");
        }
        return View(movie);
    }
    
    public IActionResult MovieList()
    {
        var movies = _context.Movies
            .OrderBy(m => m.Title)
            .ToList(); // Get the list of movies
        return View(movies); // Return the MovieList view with the list of movies
    }
    
// GET method for Edit (to display the form with the existing movie details)
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var movie = _context.Movies.Find(id);
        if (movie == null)
        {
            return NotFound();
        }
        return View(movie);  // Return the Edit view with the movie data
    }

    [HttpPost]
    public IActionResult Edit(int id, Movie movie)
    {
        if (id != movie.MovieId)
        {
            return NotFound(); // Ensure that the movie ID matches the one from the route
        }

        if (ModelState.IsValid)
        {
            _context.Update(movie); // Update the movie in the database
            _context.SaveChanges(); // Save the changes

            return RedirectToAction("MovieList"); // Redirect to the MovieList page to show the updated list
        }
    
        return View(movie);  // If the model is invalid, return the view with the movie data (for user to fix errors)
    }
    
// GET: Delete (confirmation page)
    [HttpGet]
    public IActionResult Delete(int id)
    {
        var movie = _context.Movies.FirstOrDefault(m => m.MovieId == id);
        if (movie == null)
        {
            return NotFound();
        }
        return View(movie);
    }

// POST: Delete (after confirmation)
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        var movie = _context.Movies.FirstOrDefault(m => m.MovieId == id);
        if (movie != null)
        {
            _context.Movies.Remove(movie);
            _context.SaveChanges();
        }
        return RedirectToAction("MovieList");
    }


    // POST: Movie/Create
    /*[HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Movie movie)
    {
        _context.Movies.Add(movie);
        _context.SaveChanges();
        _context.Movies.Update(movie);
        _context.SaveChanges();
        _context.Movies.Remove(movie);
        _context.SaveChanges();

        if (ModelState.IsValid)
        {
            // TODO: Add database save logic here (e.g., using EF Core)
            return RedirectToAction("Index", "Home");
        }
        return View(movie);
    }*/

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

}