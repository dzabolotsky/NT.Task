using Microsoft.EntityFrameworkCore;
using NT.Tasks.Domain.Models;
using NT.Tasks.Repository.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NT.Tasks.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<WeatherForecast> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>(builder =>
            {
                builder.ToTable("City");
                builder.Property(e => e.Id).ValueGeneratedNever();
            });
            modelBuilder.Entity<WeatherForecast>(builder =>
            {
                builder.ToTable("WeatherForecast");
                builder.Property(e => e.Id).ValueGeneratedNever();
                builder.Property(e => e.CityId).ValueGeneratedNever();
                builder.HasOne(d => d.City)
                .WithMany(p => p.WeatherForecasts)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_WEatherForecast_City");

            });

            modelBuilder.Seed();
        }
    }
}
