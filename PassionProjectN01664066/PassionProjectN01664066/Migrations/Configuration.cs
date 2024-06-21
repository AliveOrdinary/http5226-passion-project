namespace PassionProjectN01664066.Migrations
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity;
    using PassionProjectN01664066.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PassionProjectN01664066.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PassionProjectN01664066.Models.ApplicationDbContext context)
        {
            // Add mock movies
            context.Movies.AddOrUpdate(
                m => m.Title,
                new Movie { Title = "Inception", ReleaseYear = 2010, Director = "Christopher Nolan", Genre = "Sci-Fi" },
                new Movie { Title = "The Shawshank Redemption", ReleaseYear = 1994, Director = "Frank Darabont", Genre = "Drama" },
                new Movie { Title = "The Godfather", ReleaseYear = 1972, Director = "Francis Ford Coppola", Genre = "Crime" },
                new Movie { Title = "Pulp Fiction", ReleaseYear = 1994, Director = "Quentin Tarantino", Genre = "Crime" },
                new Movie { Title = "The Dark Knight", ReleaseYear = 2008, Director = "Christopher Nolan", Genre = "Action" }
            );

            context.SaveChanges();

            // Add a mock user
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);
            ApplicationUser mockUser;
            if (!context.Users.Any(u => u.UserName == "mockuser@example.com"))
            {
                mockUser = new ApplicationUser { UserName = "mockuser@example.com", Email = "mockuser@example.com" };
                userManager.Create(mockUser, "MockPassword123!");
            }
            else
            {
                mockUser = context.Users.FirstOrDefault(u => u.UserName == "mockuser@example.com");
            }

            context.SaveChanges();

            if (mockUser != null)
            {
                // Add mock reviews
                context.Reviews.AddOrUpdate(
                    r => new { r.UserId, r.MovieId },
                    new Review { UserId = mockUser.Id, MovieId = context.Movies.FirstOrDefault(m => m.Title == "Inception").MovieId, Rating = 5, ReviewText = "Mind-bending and visually stunning!" },
                    new Review { UserId = mockUser.Id, MovieId = context.Movies.FirstOrDefault(m => m.Title == "The Shawshank Redemption").MovieId, Rating = 5, ReviewText = "A timeless classic." }
                );

                // Add mock watchlist items
                context.Watchlist.AddOrUpdate(
                    w => new { w.UserId, w.MovieId },
                    new Watchlist { UserId = mockUser.Id, MovieId = context.Movies.FirstOrDefault(m => m.Title == "Pulp Fiction").MovieId },
                    new Watchlist { UserId = mockUser.Id, MovieId = context.Movies.FirstOrDefault(m => m.Title == "The Dark Knight").MovieId }
                );
            }

            context.SaveChanges();
        }
    }
}
