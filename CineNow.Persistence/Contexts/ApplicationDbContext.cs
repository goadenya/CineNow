using CineNow.Domain.Common;
using CineNow.Domain.Common.Interfaces;
using CineNow.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CineNow.Persistence.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IDomainEventDispatcher _dispatcher;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,
            IDomainEventDispatcher dispatcher)
        : base(options)
        {
            _dispatcher = dispatcher;
        }

        public DbSet<Movie> Movies => Set<Movie>();
        public DbSet<Booking> Bookings => Set<Booking>();
        public DbSet<Seat> Seats => Set<Seat>();
        public DbSet<SeatRow> SeatRows => Set<SeatRow>();
        public DbSet<Showtime> Showtimes => Set<Showtime>();
        public DbSet<Theater> Theaters => Set<Theater>();
        public DbSet<Venue> Venues => Set<Venue>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            if (_dispatcher == null) return result;

            var entitiesWithEvents = ChangeTracker.Entries<BaseEntity>()
                .Select(e => e.Entity)
                .Where(e => e.DomainEvents.Any())
                .ToArray();

            await _dispatcher.DispatchAndClearEvents(entitiesWithEvents);

            return result;
        }

        public override int SaveChanges()
        {
            return SaveChangesAsync().GetAwaiter().GetResult();
        }
    }
}
