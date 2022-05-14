using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class MovieRepository: IMovieRepository
    {        
        public List<Movie> GetTop30GrossingMovies()
        {
            // ApplicationCore.Contracts.Repositories.IMovieRepository -> Infrastructure.Repositories.MovieRepository
            // dommy data
            var movies = new List<Movie>()
            {
                new Movie { Id = 1, Title="Inception", PosterUrl="https://image.tmdb.org/t/p/w342//9gk7adHYeDvHkCSEqAvQNLV5Uge.jpg"},
                new Movie { Id = 2, Title="Inception", PosterUrl="https://image.tmdb.org/t/p/w342//9gk7adHYeDvHkCSEqAvQNLV5Uge.jpg"},
                new Movie { Id = 3, Title="Inception", PosterUrl="https://image.tmdb.org/t/p/w342//9gk7adHYeDvHkCSEqAvQNLV5Uge.jpg"},
                new Movie { Id = 4, Title="Inception", PosterUrl="https://image.tmdb.org/t/p/w342//9gk7adHYeDvHkCSEqAvQNLV5Uge.jpg"},
                new Movie { Id = 5, Title="Inception", PosterUrl="https://image.tmdb.org/t/p/w342//9gk7adHYeDvHkCSEqAvQNLV5Uge.jpg"},
                new Movie { Id = 6, Title="Inception", PosterUrl="https://image.tmdb.org/t/p/w342//9gk7adHYeDvHkCSEqAvQNLV5Uge.jpg"},
                new Movie { Id = 7, Title="Inception", PosterUrl="https://image.tmdb.org/t/p/w342//9gk7adHYeDvHkCSEqAvQNLV5Uge.jpg"},
                new Movie { Id = 8, Title="Inception", PosterUrl="https://image.tmdb.org/t/p/w342//9gk7adHYeDvHkCSEqAvQNLV5Uge.jpg"}

            };

            return movies;
        }  
    }
}
