using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4HW3.Services
{
    public class ApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                .Build();
            var connectionString = config.GetConnectionString("DefaultConnection");
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseSqlServer(connectionString)
                .Options;

            return new ApplicationContext(options);
        }
    }
}
