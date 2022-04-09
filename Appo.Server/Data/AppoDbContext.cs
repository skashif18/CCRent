namespace Appo.Server.Data
{

    using Appo.Server.Data.Models;
    using Appo.Server.Data.Models.Base;
    using Appo.Server.Infrastructure.Services;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.AspNetCore.Razor.TagHelpers;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class AppoDbContext : IdentityDbContext<User>
    {
        private readonly ICurrentUserService currentUser;
        public AppoDbContext(DbContextOptions<AppoDbContext> options, ICurrentUserService currentUser)
           : base(options)
        {
            this.currentUser = currentUser;
        }
       
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            ApplyAuditInformation();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            ApplyAuditInformation();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Profile> Profiles { get; set; }

        public DbSet<Follow> Follows { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Package>()
                .HasQueryFilter(m=>!m.IsDeleted)
                .HasOne(p => p.User)
                .WithMany(u => u.Packages)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict);


            builder
                .Entity<User>()
                .HasOne(m => m.Profile)
                .WithOne()
                .HasForeignKey<Profile>(m => m.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Follow>()
                .HasOne(f => f.User)
                .WithMany()
                .HasForeignKey(m=>m.UserId)
                .OnDelete(DeleteBehavior.Restrict);


            base.OnModelCreating(builder);
        }

        private void ApplyAuditInformation()
            => this.ChangeTracker
                .Entries()
                .ToList()
                .ForEach(entry => {
                    var userName = this.currentUser.GetUserName();
                    if (entry.Entity is IDeletableEntity deletableEntity)
                    {
                        if (entry.State == EntityState.Deleted) {
                            deletableEntity.DeletedOn = DateTime.UtcNow;
                            deletableEntity.DeletedBy = userName;
                            deletableEntity.IsDeleted = true;

                            entry.State = EntityState.Modified;
                        }
                    }
                    if (entry.Entity is IEntity entity) {

                        if (entry.State == EntityState.Added)
                        {
                            entity.CreatedOn = DateTime.UtcNow;
                            entity.CreatedBy = userName;
                        }
                        else if (entry.State == EntityState.Modified) {
                            entity.ModyfiedOn = DateTime.UtcNow;
                            entity.ModyfiedBy = userName;
                        }
                    }
                })
            ;
    }
}
