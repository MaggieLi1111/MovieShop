using ApplicationCore.Contracts.Services;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using MovieShop.Models;
using System.Diagnostics;

namespace MovieShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        // HomeController is not depend on MovieService class, but depend on IMovieService abstraction
        private readonly IMovieService _movieService;

        public HomeController(ILogger<HomeController> logger, IMovieService movieService)
        {
            _logger = logger;
            _movieService = movieService;
        }
        

        [HttpGet]
        public IActionResult Index()
        {
            // we can have some higher level framework to create instances

            //var movieService = new MovieService();
            //var movieCards = movieService.GetTop30GrossingMovies();

            var movieCards = _movieService.GetTop30GrossingMovies();

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