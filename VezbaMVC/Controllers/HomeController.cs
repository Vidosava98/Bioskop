using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Diagnostics;
using VezbaMVC.Models;

namespace VezbaMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MongoDbContext _context;
        public HomeController(ILogger<HomeController> logger, MongoDbContext context)
        {
            _logger = logger;
            _context = context;

        }

        public IActionResult Index()
        {
            List<String> categories = new List<String> { "Action", "Horor", "Drama", "Comedy", "Romance", "Triler", "Sci-Fi", "History", "War", "Mistery", "Cartoon", "Anime", "Animated" };
            ViewBag.MyList = categories;
            return View();
        }
        public IActionResult MovieView(String name)
        {
            var movies = _context.Movie.Find(movie => movie.Genre == name).ToList();
            ViewBag.Name = name;
            ViewBag.Movies = movies;
            return View();  
        }
        public IActionResult MovieForm(String title)
        {
            var movie = _context.Movie.Find(movie => movie.Title == title).FirstOrDefault();
            ViewBag.Movie = movie;
            return PartialView("_MovieForm", movie);
        }

        public IActionResult MovieFormAuthor(String first, String last)
        {
            var author = _context.Author.Find(author => author.FirstName == first && author.LastName == last).FirstOrDefault();
            ViewBag.Author = author;
            return PartialView("_AuthorForm", author);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
