using Boilerplate.Domain.Entities;
using Boilerplate.Domain.Entities.Theater;
using Microsoft.EntityFrameworkCore;

namespace Boilerplate.Infrastructure.Context
{
    public class HeroDbContext : DbContext
    {
        public HeroDbContext(DbContextOptions<HeroDbContext> options) : base(options) { }

        public DbSet<Hero> Heroes { get; set; }
        
        public DbSet<TimeSlotEntity> TimeSlots { get; set; }

        public DbSet<MovieEntity> Movies { get; set; }
        
        public DbSet<ReservationEntity> Reservations { get; set; }
        
        public DbSet<TheaterEntity> Theaters { get; set; }
    }
}
