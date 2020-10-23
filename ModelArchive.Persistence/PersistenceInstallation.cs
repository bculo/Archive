using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelArchive.Persistence
{
    public class PersistenceInstallation
    {
        public static void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ArchiveDbContext>(options => 
                options.UseSqlServer(configuration.GetConnectionString("ModelArchive"))
            );
        }
    }
}
