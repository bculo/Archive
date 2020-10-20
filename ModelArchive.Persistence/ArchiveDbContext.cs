using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ModelArchive.Common;
using ModelArchive.Persistence.Configurations;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ModelArchive.Persistence
{
    public class ArchiveDbContext : IdentityDbContext<IdentityUser<Guid>, IdentityRole<Guid>, Guid>
    {
        private readonly IDateTime _time;

        public ArchiveDbContext(DbContextOptions<ArchiveDbContext> options,
            IDateTime time) : base(options)
        {
            _time = time;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(SchemaType.Dbo.ToString());
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ArchiveDbContext).Assembly);
            modelBuilder.ConfigureIdentity();
            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
