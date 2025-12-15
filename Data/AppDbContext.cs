using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;

namespace Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<ReservationEntity> Reservations { get; set; }
        private string DbPath { get; set; }

        public AppDbContext()
        {
            DbPath = @"E:\data\reservations.db";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
            options.UseSqlite($"Data Source={DbPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReservationEntity>().HasData(
                new ReservationEntity() 
                { 
                    Id = 1, 
                    City = "Kraków", 
                    Address = "Wysłouchów 22", 
                    RoomName = "44",
                    Owner = "Jan Kowalski",
                    Price = 500m,
                    Date = new DateTime(2025, 05, 20)
                },
                new ReservationEntity() 
                { 
                    Id = 2, 
                    City = "Miechów", 
                    Address = "Polna 44", 
                    RoomName = "546",
                    Owner = "Anna Nowak",
                    Price = 123123m,
                    Date = new DateTime(2025, 06, 15)
                }
            );
        }
    }
}