using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace ModelArchive.Persistence
{
    public static class ArchiveDbContextSeed
    {
        public static async Task ConfigureStorage(IServiceProvider provider)
        {
            var dbConext = provider.GetRequiredService<ArchiveDbContext>();

            //apply migrations
            if (dbConext.Database.IsSqlServer())
                await dbConext.Database.MigrateAsync();


            await dbConext.DisposeAsync();
        }
    }
}
