using _66BitApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace _66BitApp.DB
{
    public class UserContext : DbContext
    {
        public DbSet<Footballer> Footballers { get; set; }
        public DbSet<Team> Team { get; set; }

        public UserContext(DbContextOptions options) : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
    }
}
