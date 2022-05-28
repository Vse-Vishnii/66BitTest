using System;
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
            //Team.Add(new Team() {Name = "A1"});
            //Team.Add(new Team() { Name = "A2" });
            //Footballers.Add(new Footballer()
            //{
            //    Country = Country.Italy, DateOfBirth = new DateTime(2000, 1, 1), Name = "Name", TeamName = "A1",
            //    Sex = Sex.Female, Surname = "Suka"
            //});
            //SaveChanges();
        }
    }
}
