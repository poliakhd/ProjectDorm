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

using System.Threading.Tasks;
using ProjectDorm.Common.Extensions;
using ProjectDorm.Common.Models.Paging;
using ProjectDorm.Domain.Database.Entities;
using ProjectDorm.Domain.Database.Providers.Interfaces;
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
    }
}