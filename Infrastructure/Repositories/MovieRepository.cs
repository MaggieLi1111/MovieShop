using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApplicationCore.Models;

namespace Infrastructure.Repositories
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        public MovieRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Movie>> GetTop30GrossingMovies()
        {
            var movies = await _dbContext.Movies.OrderByDescending(m => m.Revenue).Take(30).ToListAsync();
            return movies;
        }

        public override async Task<Movie> GetById(int id)
        {
            var movieDetails = await _dbContext.Movies.Include(m => m.MoviesOfGenre).ThenInclude(m => m.Genre)
                .Include(m => m.MoviesCasts)
                .ThenInclude(m => m.Cast)
                .Include(m => m.Trailers)
                .FirstOrDefaultAsync(m => m.Id == id);
            return movieDetails;
        }

        public async Task<PagedResultSet<Movie>> GetMoviesByGenres(int genreId, int pageSize = 30, int pageNumber = 1)
        {
            var totalMoviesCountByGenre = await _dbContext.MovieGenres.Where(m => m.GenreId == genreId).CountAsync();

            if (totalMoviesCountByGenre == 0)
            {
                throw new Exception("No Movies found for that genre");
            }

            var movies = await _dbContext.MovieGenres
                .Where(g => g.GenreId == genreId).Include(m => m.Movie)
                .OrderBy(m => m.MovieId)
                .Select(movie => new Movie
                 {
                    Id = movie.MovieId,
                    PosterUrl = movie.Movie.PosterUrl,
                    Title = movie.Movie.Title,
                 })
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var pagedMovies = new PagedResultSet<Movie>(movies, pageNumber, pageSize, totalMoviesCountByGenre);
            return pagedMovies;
        }
    }
}
