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
            modelBuilder.Entity<MovieGenre>(ConfigureMovieGenre);
            modelBuilder.Entity<MovieCrew>(ConfigureMovieCrew);
            modelBuilder.Entity<MovieCast>(ConfigureMovieCast);
            modelBuilder.Entity<UserRole>(ConfigureUserRole);
            modelBuilder.Entity<Review>(ConfigureReview);
        }

        private void ConfigureGenre(EntityTypeBuilder<Genre> builder)
        {
            //specify the Fluent API way rules for Genre Table
            builder.ToTable("Genre");
            builder.HasKey(g => g.Id);
            builder.Property(g => g.Name).HasMaxLength(64).IsRequired();
        }

        private void ConfigureMovieGenre(EntityTypeBuilder<MovieGenre> builder)
        {
            builder.ToTable("MovieGenre");
            builder.HasKey(mg => new
            {
                mg.MovieId,
                mg.GenreId
            });
        }

        private void ConfigureMovieCrew(EntityTypeBuilder<MovieCrew> builder)
        {
            builder.ToTable("MovieCrew");
            builder.HasKey(mc => new
            {
                mc.MovieId,
                mc.CrewId
            });
            builder.Property(mc => mc.Department).HasMaxLength(128).IsRequired();
            builder.Property(mc => mc.Job).HasMaxLength(128).IsRequired();
          
        }

        private void ConfigureMovieCast(EntityTypeBuilder<MovieCast> builder)
        {
            builder.ToTable("MovieCast");
            builder.HasKey(moviecast => new
            {
                moviecast.MovieId,
                moviecast.CastId,
            });
            builder.Property(moviecast => moviecast.Character).HasMaxLength(450).IsRequired();
        }

        private void ConfigureUserRole(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable("UserRole");
            builder.HasKey(userrole => new
            {
                userrole.UserId,
                userrole.RoleId,
            });
        }
        private void ConfigureReview(EntityTypeBuilder<Review> builder)
        {
            builder.ToTable("Review");
            builder.HasKey(review => new 
            { 
            review.MovieId,
            review.UserId,
            });
            builder.Property(review => review.Rating).HasColumnType("decimal(3,2)").IsRequired();
            builder.Property(review => review.ReviewText);
            
        }
        public DbSet<Trailer> Trailers { get; set; }

        public DbSet<MovieGenre> MovieGenres { get; set; }      

        public DbSet<User> Users { get; set; }

        public DbSet<Crew> Crews { get; set; }

        public DbSet<MovieCrew> MovieCrews { get; set; }
        public DbSet<Cast> Casts { get; set; }
        public DbSet<MovieCast> MovieCasts { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Purchase> Purchases { get; set; }

        public DbSet<Favorite> Favorites  { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }
}
