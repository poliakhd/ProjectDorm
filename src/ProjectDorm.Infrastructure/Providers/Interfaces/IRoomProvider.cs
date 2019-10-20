// <copyright file="IRoomProvider.cs" company="">
// Copyright (c) 2019 All Rights Reserved
// </copyright>
// <author>Daniil Poliakh</author>
// <date>20/04/2019 7:45 PM</date>
// <summary>
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// </summary>

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectDorm.Common.Models.Paging;
using ProjectDorm.Domain.Database.Entities;
using ProjectDorm.Domain.Models;

namespace ProjectDorm.Infrastructure.Providers.Interfaces
{
    /// <summary>
    /// Room provider interface
    /// </summary>
    public interface IRoomProvider
    {
        /// <summary>
        /// Asynchronous method for getting all rooms
        /// </summary>
        /// <param name="paging">Paging model</param>
        /// <returns>List of room entities</returns>
        Task<PagedResult<RoomEntity>> GetRoomsAsync(PagingModel paging);

        /// <summary>
        /// Asynchronous method for getting available dates for specified room
        /// </summary>
        /// <param name="id">Room id</param>
        /// <returns>List of available date ranges</returns>
        Task<IEnumerable<DateRangeModel>> GetAvailableRoomDates(int id);

        /// <summary>
        /// Asynchronous method for getting available rooms for specified dates
        /// </summary>
        /// <param name="startDate">Start date</param>
        /// <param name="endDate">End date</param>
        /// <param name="paging">Paging model</param>
        /// <returns>List of available rooms</returns>
        Task<PagedResult<RoomEntity>> GetAvailableRooms(DateTime startDate, DateTime endDate, PagingModel paging);
    }
}