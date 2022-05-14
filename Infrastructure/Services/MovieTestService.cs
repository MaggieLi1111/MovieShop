﻿using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class MovieTestService : IMovieService
    {
        public List<MovieCardModel> GetTop30GrossingMovies()
        {
            var movieRepo = new MovieRespository();
            var movies = movieRepo.GetTop30GrossingMovies();

        }
    }
}
