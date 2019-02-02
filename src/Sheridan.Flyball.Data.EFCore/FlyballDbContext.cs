using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Sheridan.Data.EntityFramework.Extensions;
using Sheridan.Flyball.Core.Entities;
using Sheridan.Flyball.Core.Enumerations;

namespace FlyballStatTracker.Data.EfCore
{
    public class FlyballDbContext : DbContext
    {
        public FlyballDbContext(DbContextOptions<FlyballDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<Division> Divisions { get; set; }
        public DbSet<Dog> Dogs { get; set; }
        public DbSet<DogPosition> DogPositions { get; set; }
        public DbSet<DogRun> DogRuns { get; set; }
        public DbSet<Heat> Heats { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<RaceYear> RaceYears { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Fault> Faults { get; set; }
        public DbSet<Outcome> Outcomes { get; set; }
        public DbSet<LaneSide> Lane { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<RacingClass> RacingClasses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.AddEntityConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
