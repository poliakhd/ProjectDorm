// <copyright file="RoomProvider.cs" company="">
// Copyright (c) 2019 All Rights Reserved
// </copyright>
// <author>Daniil Poliakh</author>
// <date>20/04/2019 7:46 PM</date>
// <summary>
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// </summary>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectDorm.Common.Extensions;
using ProjectDorm.Common.Models.Paging;
using ProjectDorm.Domain.Database.Entities;
using ProjectDorm.Domain.Database.Providers.Interfaces;
using ProjectDorm.Domain.Models;
using ProjectDorm.Infrastructure.Providers.Interfaces;

namespace ProjectDorm.Infrastructure.Providers
{
    /// <summary>
    /// Base room provider
    /// </summary>
    public class RoomProvider : IRoomProvider
    {
        private readonly ILinqProvider _linqProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="RoomProvider" /> class.
        /// </summary>
        public RoomProvider(ILinqProvider linqProvider)
        {
            _linqProvider = linqProvider;
        }

        /// <inheritdoc />
        public async Task<PagedResult<RoomEntity>> GetRoomsAsync(int page, int size)
        {
            var rooms = await _linqProvider.Query<RoomEntity>()
                .AsPagedAsync(page, size);

            return rooms;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<DateRangeModel>> GetAvailableRoomDates(int id)
        {
            var room = await _linqProvider.Query<RoomEntity>()
                .Where(x => x.Id == id)
                .Include(x => x.Bookings)
                .FirstOrDefaultAsync();

            var orderedRoomBookings = room.Bookings
                .OrderBy(x => x.StartDate)
                .Where(x => x.StartDate > DateTime.Now && x.EndDate > DateTime.Now)
                .ToList();

            if (!orderedRoomBookings.Any())
            {
                return new[] {new DateRangeModel {From = DateTime.Now.Date}};
            }

            var result = new List<DateRangeModel>();

            for (int i = 0; i < orderedRoomBookings.Count; i++)
            {
                if (i + 1 <= orderedRoomBookings.Count - 1 && orderedRoomBookings[i].EndDate.AddDays(1) < orderedRoomBookings[i + 1].StartDate)
                {
                    result.Add(new DateRangeModel()
                    {
                        From = orderedRoomBookings[i].EndDate.AddDays(1),
                        To = orderedRoomBookings[i + 1].StartDate.AddDays(-1)
                    });
                }
                else if(i == orderedRoomBookings.Count - 1)
                {
                    result.Add(new DateRangeModel()
                    {
                        From = orderedRoomBookings[i].EndDate.AddDays(1)
                    });
                }
            }

            return result;
        }
    }
}