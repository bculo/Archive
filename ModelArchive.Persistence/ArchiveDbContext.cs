﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ModelArchive.Common;
using ModelArchive.Core.Entities;
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

        public ArchiveDbContext(DbContextOptions options,
            IDateTime time) : base(options)
        {
            _time = time;
        }

        public DbSet<ModelFolder> Folders { get; set; }
        public DbSet<Model3D> Models { get; set; }
        public DbSet<ModelImage> ModelImages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //set default database schema
            modelBuilder.HasDefaultSchema(SchemaType.Dbo.ToString());

            //configure custom entites via fluent validation
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ArchiveDbContext).Assembly);

            //configure identity (used for authentication and authorization)
            modelBuilder.ConfigureIdentity();

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach(var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        break;

                    case EntityState.Modified:
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
