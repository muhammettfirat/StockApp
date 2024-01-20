using StockApp.Api.Core.Domain;
using StockApp.Api.Core.Helper;
using StockApp.Api.Persistance.Configurations;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Security.Claims;

namespace StockApp.Api.Persistance.Context
{
    public class StockAppContext : DbContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public StockAppContext(DbContextOptions options, IHttpContextAccessor httpContextAccessor = null) : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public DbSet<StockType> StockTypes { get; set; }
        public DbSet<StockCard> StockCards { get; set; }
        public DbSet<StockUnit> StockUnits { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            base.OnModelCreating(modelBuilder);
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<TrackedAggregateRoot<Guid>>();
            if (_httpContextAccessor != null && _httpContextAccessor.HttpContext != null)
            {
                var loggedInUserId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            }

            var _users = new AppUser();
            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property(p => p.Id)
                        .CurrentValue = Guid.NewGuid();
                    entry.Property(p => p.CreationTime)
                        .CurrentValue = DateTime.Now;
                    entry.Property(p => p.CreatorId)
                       .CurrentValue = _users.Id;
                }
                if (entry.State == EntityState.Modified)
                {
                    entry.Property(p => p.Id)
                        .IsModified = false;
                    entry.Property(p => p.LastModificationTime)
                        .CurrentValue = DateTime.Now;
                    entry.Property(p => p.LastModifierId)
                       .CurrentValue = _users.Id;
                }
                if (entry.State == EntityState.Modified && entry.Entity.IsDeleted==true)
                {
                    entry.Property(p => p.DeletionTime)
                        .CurrentValue = DateTime.Now;
                    entry.Property(p => p.DeleterId)
                       .CurrentValue = _users.Id;
                    entry.Property(p => p.IsDeleted)
                        .CurrentValue = true;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
