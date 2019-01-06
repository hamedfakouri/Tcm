using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Tcm.Persistence.Ef
{
  

    public class TcmContextFactory : IDesignTimeDbContextFactory<TcmContext>
    {
        public TcmContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<TcmContext>();


            builder.UseSqlServer(configuration.GetConnectionString("TransportCentralizedManagementConnection"));

            return new TcmContext(builder.Options);
        }



    }
}
