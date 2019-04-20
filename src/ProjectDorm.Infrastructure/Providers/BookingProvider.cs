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

using System;
using System.Threading.Tasks;
using ProjectDorm.Common.Extensions;
using ProjectDorm.Common.Models.Paging;
using ProjectDorm.Domain.Database.Entities;
using ProjectDorm.Domain.Database.Providers.Interfaces;
using ProjectDorm.Domain.Database.Repositories.Interfaces;
using ProjectDorm.Domain.Models;
using ProjectDorm.Infrastructure.Providers.Interfaces;

namespace ProjectDorm.Infrastructure.Providers
{
    /// <summary>
    /// Base booking provider
    /// </summary>
    public class BookingProvider : IBookingProvider
    {
        private readonly ILinqProvider _linqProvider;
        private readonly IDbRepository<BookingEntity, int> _bookingRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookingProvider" /> class.
        /// </summary>
        public BookingProvider(ILinqProvider linqProvider, IDbRepository<BookingEntity, int> bookingRepository)
        {
            _linqProvider = linqProvider;
            _bookingRepository = bookingRepository;
        }

        /// <inheritdoc />
        public async Task<PagedResult<BookingEntity>> GetBookingsAsync(int page, int size)
        {
            var bookings = await _linqProvider.Query<BookingEntity>()
                .AsPagedAsync(page, size);

            return bookings;
        }

        /// <inheritdoc />
        public async Task<BookingEntity> AddBookingAsync(int roomId, DateTime startDate, DateTime endDate)
        {
            var result = await _bookingRepository.AddAsync(new BookingEntity()
            {
                RoomId = roomId,
                StartDate = startDate,
                EndDate = endDate,
                Size = 1,
                GenderModel = GenderModel.Male
            });
            await _bookingRepository.SaveAsync();

            return result;
        }
    }
}