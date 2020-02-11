using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace Money_Exchange.API.Infraestructure.Context
{
    public class BaseContext : DbContext
    {
        public BaseContext()
        {
        }

        public BaseContext(DbContextOptions options) : base(options)
        {
        }

        public override int SaveChanges()
        {
            AuditEntities();

            return base.SaveChanges();
        }

        private void AuditEntities()
        {
            var currentUserName = 1;
            var currentDateTime = DateTime.UtcNow;

            foreach (var entry in ChangeTracker.Entries())
            {
                const StringComparison currentCultureIgnoreCase = StringComparison.CurrentCultureIgnoreCase;

                if (entry.State == EntityState.Added)
                {
                    if (entry.Properties.Any(p => string.Equals(p.Metadata.Name, "CreatorUserId", currentCultureIgnoreCase)))
                        entry.Property("CreatorUserId").CurrentValue = currentUserName;

                    if (entry.Properties.Any(p => string.Equals(p.Metadata.Name, "CreationDate", currentCultureIgnoreCase)))
                        entry.Property("CreationDate").CurrentValue = currentDateTime;
                }

                if (entry.State == EntityState.Modified)
                {
                    if (entry.Properties.Any(p => string.Equals(p.Metadata.Name, "ModifierUserId", currentCultureIgnoreCase)))
                        entry.Property("ModifierUserId").CurrentValue = currentUserName;

                    if (entry.Properties.Any(p => string.Equals(p.Metadata.Name, "ModificationDate", currentCultureIgnoreCase)))
                        entry.Property("ModificationDate").CurrentValue = currentDateTime;
                }
            }
        }
    }
}
