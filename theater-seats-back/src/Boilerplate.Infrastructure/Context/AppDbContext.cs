using System;
using Boilerplate.Domain.Entities;
using Boilerplate.Domain.Entities.Theater;
using Microsoft.EntityFrameworkCore;

namespace Boilerplate.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<TimeSlotEntity> TimeSlots { get; set; }

        public DbSet<MovieEntity> Movies { get; set; }

        public DbSet<ReservationEntity> Reservations { get; set; }

        public DbSet<TheaterEntity> Theaters { get; set; }
    }
}