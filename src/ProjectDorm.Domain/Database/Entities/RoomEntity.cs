// <copyright file="RoomEntity.cs" company="">
// Copyright (c) 2019 All Rights Reserved
// </copyright>
// <author>Daniil Poliakh</author>
// <date>19/04/2019 9:57 PM</date>
// <summary>
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// </summary>

using System.Collections.Generic;
using ProjectDorm.Domain.Database.Entities.Interfaces;

namespace ProjectDorm.Domain.Database.Entities
{
    /// <summary>
    /// Dorm room entity
    /// </summary>
    public class RoomEntity : IEntity
    {
        /// <summary>
        /// Gets or sets room id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets room size
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// Gets or sets bookings
        /// </summary>
        public ICollection<BookingEntity> Bookings { get; set; }
    }
}