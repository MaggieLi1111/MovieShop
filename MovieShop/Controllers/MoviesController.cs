using Microsoft.AspNetCore.Mvc;

namespace MovieShopMVC.Controllers
{
    public class MoviesController : Controller
    {
        public IActionResult Details(int id)
        {
            // go to Movies table and get the movie details by Id
            // connect to SQL Server and execute the SQL query
            // select * from Movie where id = 2
            // get the movies entities (object)

            // Repositories => Data acces logic
            // Services => business logic
            // Controller action methods => Services methods => Repository methods => SQL database 
            // get the model data from the services and send the data to the views
            return View();
        }
    }
}