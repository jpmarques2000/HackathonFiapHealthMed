using Hackathon.HealthMed.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using TechChallenge.AutomotiveMechanics.Infrastructure.Data.SeedData;

namespace Hackathon.HealthMed.Infraestructure
{
    public class ApplicationDbContext : DbContext
    {
        public readonly IConfiguration _configuration;

        //public ApplicationDbContext(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            //_configuration = configuration;
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Medic> Medics { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Patient> Patient { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (_configuration != null)
            //{
            //    optionsBuilder.UseSqlServer(
            //        _configuration.GetConnectionString("AutomotiveMechanics"));
            //}
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            modelBuilder.Seed();
        }
    }
}
