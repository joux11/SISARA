using Microsoft.EntityFrameworkCore;
using SISARA.Domain.Common;
using SISARA.Domain.Entities;

namespace SISARA.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) 
        {
            
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            
            foreach(var entry in ChangeTracker.Entries<BaseAuditableEntity>())
            {
                entry.Entity.OnSaveAuditable();
            }
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           
            
        }


        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserDevice> UserDevices {  get; set; }

    }
}
