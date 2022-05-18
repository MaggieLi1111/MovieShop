using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class MovieRepository: Repository<Movie>, IMovieRepository
    {
        public MovieRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }

        public List<Movie> GetTop30GrossingMovies()
        {
            var movies = _dbContext.Movies.OrderByDescending(m => m.Revenue).Take(30).ToList();
            return movies;
        }
        public override Movie GetById(int id)
        {
            var movie = _dbContext.Movies.Include(m=> m.MoviesOfGenre).ThenInclude(m => m.Genre)
                .Include(m=> m.MoviesCasts)
                .ThenInclude(m => m.Cast)
                .Include(m => m.Trailers)
                .FirstOrDefault(m => m.Id == id);
            return movie;
        }
    }
}
