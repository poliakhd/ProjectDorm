// <copyright file="AppDbContextFactory.cs" company="">
// Copyright (c) 2019 All Rights Reserved
// </copyright>
// <author>Daniil Poliakh</author>
// <date>21/04/2019 10:16 PM</date>
// <summary>
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// </summary>

using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using ProjectDorm.Domain.Database;

namespace ProjectDorm.Api.Migrations
{
    /// <summary>
    /// <see cref="AppDbContext"/> design factory
    /// </summary>
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        /// <inheritdoc />
        public AppDbContext CreateDbContext(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = config.GetConnectionString("MsSqlServer");

            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer(connectionString, b => b.MigrationsAssembly("ProjectDorm.Domain"));

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}