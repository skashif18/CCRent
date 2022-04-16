namespace Appo.Server.Data
{
    using Appo.Server.Infrastructure.Services;
    using CoreBusiness.Base;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class AppoDbContext : IdentityDbContext
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
                            entity.CreationDate = DateTime.UtcNow;
                            entity.CreationUserName = userName;
                        }
                        else if (entry.State == EntityState.Modified) {
                            entity.LastUpdateDate = DateTime.UtcNow;
                            entity.LastUpdateUserName = userName;
                        }
                    }
                })
            ;
    }
}
