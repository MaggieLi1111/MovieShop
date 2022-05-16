using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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

        // To use fluent API, you need to override OnModelCreating
        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // you can specify the rules for Entity
            modelBuilder.Entity<Genre>(ConfigureGenre);
        }

        private void ConfigureGenre(EntityTypeBuilder<Genre> builder)
        {
            //specify the Fluent API way rules for Genre Table
            builder.ToTable("Genre");
            builder.HasKey(g => g.Id);
            builder.Property(g => g.Name).HasMaxLength(64).IsRequired();
        }
    }
}
