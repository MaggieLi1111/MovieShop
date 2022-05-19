using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopMVC.Controllers
{
    public class MoviesController : Controller
        
    {
        private readonly IMovieService _movieService;
        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        public async Task<IActionResult> Details(int id)
        {
            // go to Movies table and get the movie details by Id
            // connect to SQL Server and execute the SQL query
            // select * from Movie where id = 2
            // get the movies entities (object)

            // Repositories => Data acces logic
            // Services => business logic
            // Controller action methods => Services methods => Repository methods => SQL database 
            // get the model data from the services and send the data to the views
            // CPU Bound operaiton(Calculations,image process) 
            // I/O Bound operation(database calls, file, images, videos), speed depending on network speed, sql server, query=> server memory
            var movieDetails = await _movieService.GetMovieDetails(id);
            return View(movieDetails);
        }
    }
}