using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ModelArchive.Persistence
{
    public class ArchiveDbContextFactory : IDesignTimeDbContextFactory<ArchiveDbContext>
    {
        public ArchiveDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

            var optionsBuilder = new DbContextOptionsBuilder();

            var connectionString = configuration
                        .GetConnectionString("ModelArchive");

            optionsBuilder.UseSqlServer(connectionString);

            return new ArchiveDbContext(optionsBuilder.Options, null);
        }
    }
}
