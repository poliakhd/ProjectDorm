// <copyright file="BookingProvider.cs" company="">
// Copyright (c) 2019 All Rights Reserved
// </copyright>
// <author>Daniil Poliakh</author>
// <date>19/04/2019 10:09 PM</date>
// <summary>
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// </summary>

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectDorm.Domain.Database.Entities;
using ProjectDorm.Domain.Database.Providers.Interfaces;
using ProjectDorm.Domain.Dto;
using ProjectDorm.Infrastructure.Providers.Interfaces;

namespace ProjectDorm.Infrastructure.Providers
{
    public class BookingProvider : IBookingProvider
    {
        private readonly ILinqProvider _linqProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookingProvider" /> class.
        /// </summary>
        public BookingProvider(ILinqProvider linqProvider)
        {
            _linqProvider = linqProvider;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<BookingDto>> GetBookingsAsync()
        {
            var bookings = await _linqProvider.Query<BookingEntity>()
                .ToListAsync();

            return bookings.Select(x => new BookingDto
                {
                    RoomId = x.RoomId,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate
                });
        }
    }
}