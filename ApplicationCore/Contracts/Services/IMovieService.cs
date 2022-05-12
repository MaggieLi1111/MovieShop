﻿using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts.Services
{
    public interface IMovieService
    {
        // home/index action method will call this method
        List<MovieCardModel> GetTop30GrossingMovies();
         
    }
}
