using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class MovieService : IMovieService
    {
        public List<MovieCardModel> GetTop30GrossingMovies()
        {
            // call the movie repository class
            // get the entity class data and map them into model class data
            var movieRepo = new MovieRepository();
            var movies = movieRepo.GetTop30GrossingMovies();  

            var movieCards = new List<MovieCardModel>();

            foreach (var movie in movies)
            {
                movieCards.Add(new MovieCardModel
                {
                    Id = movie.Id,
                    PosterUrl = movie.PosterUrl,
                    Title = movie.Title,
                });
            }

            return movieCards;
          
        }
    }
}
  