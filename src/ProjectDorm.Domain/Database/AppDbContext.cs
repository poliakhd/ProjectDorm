// <copyright file="AppDbContext.cs" company="10Apps">
// Copyright (c) 2019 All Rights Reserved
// </copyright>
// <author>Daniil Poliakh</author>
// <date>19/04/2019 9:37 PM</date>
// <summary>
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// </summary>

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectDorm.Domain.Database.Configurations;
using ProjectDorm.Domain.Database.Entities;

namespace ProjectDorm.Domain.Database
{
    /// <summary>
    /// App database context
    /// </summary>
    public class AppDbContext : IdentityDbContext<AppUserEntity, AppUserRoleEntity, int>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppDbContext" /> class.
        /// </summary>
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options)
        {
        }

        /// <inheritdoc />
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new BookingEntityConfiguration());
            builder.ApplyConfiguration(new RoomEntityConfiguration());
        }

        /// <summary>
        /// Gets or sets rooms db set
        /// </summary>
        public DbSet<RoomEntity> Rooms { get; set; }

        /// <summary>
        /// Gets or sets bookings db set
        /// </summary>
        public DbSet<BookingEntity> Bookings { get; set; }
    }
}