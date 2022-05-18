using ApplicationCore.Contracts.Repositories;
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
        private readonly IMovieRepository _movieRepository;
        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public List<MovieCardModel> GetTop30GrossingMovies()
        {
            // Service: only related to the implementation (Model View)
            // ApplicationCore -> Contracts -> Services -> IMovieService(interface, no body) -> Infrastructure.Services -> MovieService(model, implementation)
            // first: call MovieRepository class
            // second: get the entity class data and map them into model class data


            
            var movies = _movieRepository.GetTop30GrossingMovies();  

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
  