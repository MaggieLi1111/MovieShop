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

        public async Task<MovieDetailsModel> GetMovieDetails(int movieId)
        {
            var movie = await _movieRepository.GetById(movieId);
            var movieDetails = new MovieDetailsModel
            {
                Id = movie.Id,
                Budget = movie.Budget,
                Overview = movie.Overview,
                Price = movie.Price,
                PosterUrl = movie.PosterUrl,
                Revenue = movie.Revenue,
                ReleaseDate = movie.ReleaseDate.GetValueOrDefault(),
                
                Tagline = movie.Tagline,
                Title = movie.Title,
                RunTime = movie.RunTime,
                BackdropUrl = movie.BackdropUrl,
               
                ImdbUrl = movie.ImdbUrl,
                TmdbUrl = movie.TmdbUrl,

            };

            foreach (var trailer in movie.Trailers)
            {
                movieDetails.Trailers.Add(new TrailerModel
                {
                    Id = trailer.Id,
                    Name = trailer.Name,
                    TrailerUrl = trailer.TrailerUrl,

                });
            }

            foreach (var genre in movie.MoviesOfGenre)
            {
                movieDetails.Genres.Add(new GenreModel
                {
                    Id = genre.GenreId,
                    Name = genre.Genre.Name
                });
            }

            foreach (var cast in movie.MoviesCasts)
            {
                movieDetails.Casts.Add(new CastModel
                {
                    Id = cast.CastId,
                    Name = cast.Cast.Name,
                    Character = cast.Character,
                    ProfilePath = cast.Cast.ProfilePath,
                };
                   
            }
            return movieDetails;
        }

        public async Task < List<MovieCardModel>>  GetTop30GrossingMovies()
        {
            // Service: only related to the implementation (Model View)
            // ApplicationCore -> Contracts -> Services -> IMovieService(interface, no body) -> Infrastructure.Services -> MovieService(model, implementation)
            // first: call MovieRepository class
            // second: get the entity class data and map them into model class data


            
            var movies = await _movieRepository.GetTop30GrossingMovies();  

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
  