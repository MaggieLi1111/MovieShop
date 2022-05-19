using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts.Services
{
    public interface IMovieService
    {
        // have all the business logic methods relating to Movies
        // home/index action method will call this method
        Task<List<MovieCardModel>> GetTop30GrossingMovies();

        Task<MovieDetailsModel> GetMovieDetails(int movieId);

        Task<PagedResultSet<MovieCardModel>> GetMoviesByGenrePagination(int genreId, int pageSize = 30, int pageNumber = 1);
         
    }
}
