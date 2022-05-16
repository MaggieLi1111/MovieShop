using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class MovieShopDbContext: DbContext
    {
        // DbContext represents database
        public MovieShopDbContext(DbContextOptions<MovieShopDbContext> options):base(options)
        {

        }

        // DbSet represents tables
        // create DbSet<Entity> property inside the DbContext
        public DbSet<Movie> Movies { get; set; }

    }
}
