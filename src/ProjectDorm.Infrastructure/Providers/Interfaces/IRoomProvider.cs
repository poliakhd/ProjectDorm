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
        /// <returns>List of room entities</returns>
        Task<PagedResult<RoomEntity>> GetRoomsAsync(int page, int size);

        /// <summary>
        /// Asynchronous method for getting available dates from specified room
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IEnumerable<DateRangeModel>> GetAvailableRoomDates(int id);
    }
}