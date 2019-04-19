// <copyright file="BookingEntityConfiguration.cs" company="">
// Copyright (c) 2019 All Rights Reserved
// </copyright>
// <author>Daniil Poliakh</author>
// <date>19/04/2019 11:11 PM</date>
// <summary>
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// </summary>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectDorm.Domain.Database.Entities;

namespace ProjectDorm.Domain.Database.Configurations
{
    public class BookingEntityConfiguration : IEntityTypeConfiguration<BookingEntity>
    {
        /// <inheritdoc />
        public void Configure(EntityTypeBuilder<BookingEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasOne(x => x.Room)
                .WithMany(x => x.Bookings);
        }
    }
}