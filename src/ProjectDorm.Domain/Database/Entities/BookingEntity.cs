// <copyright file="BookingEntity.cs" company="">
// Copyright (c) 2019 All Rights Reserved
// </copyright>
// <author>Daniil Poliakh</author>
// <date>19/04/2019 10:02 PM</date>
// <summary>
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// </summary>

using System;
using ProjectDorm.Domain.Models;
using ProjectDorm.Domain.Database.Entities.Interfaces;

namespace ProjectDorm.Domain.Database.Entities
{
    /// <summary>
    /// Dorm booking entity
    /// </summary>
    public class BookingEntity : IEntity
    {
        /// <inheritdoc/>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets room id <see cref="Room"/>
        /// </summary>
        public int RoomId { get; set; }

        /// <summary>
        /// Gets or sets room
        /// </summary>
        public RoomEntity Room { get; set; }

        /// <summary>
        /// Gets or sets used room size
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// Gets or sets start booking date
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Gets or sets end booking date
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Gets or sets booking gender
        /// </summary>
        public GenderModel GenderModel { get; set; }
    }
}