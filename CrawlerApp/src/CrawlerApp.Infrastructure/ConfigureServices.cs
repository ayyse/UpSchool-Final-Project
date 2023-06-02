﻿using CrawlerApp.Application.Common.Interfaces;
using CrawlerApp.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySqlConnector;

namespace CrawlerApp.Infrastructure
{
    public static class ConfigureServices
    {
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("MariaDB")!;

            // DbContext
            services.AddDbContext<ApplicationDbContext>(opt => opt.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());
        }
    }
}
