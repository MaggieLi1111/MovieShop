using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using MovieShop.Models;
using System.Diagnostics;

namespace MovieShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        

        [HttpGet]
        public IActionResult Index()
        {
            var movieService = new MovieService();
            var movieCards = movieService.GetTop30GrossingMovies();

            // passing the data from controller action method to Views
            return View(movieCards);
        }

        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult TopRatedMovies()
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