// <copyright file="IBookingProvider.cs" company="10Apps">
// Copyright (c) 2019 All Rights Reserved
// </copyright>
// <author>Daniil Poliakh</author>
// <date>19/04/2019 9:35 PM</date>
// <summary>
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// </summary>

using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectDorm.Domain.Dto;

namespace ProjectDorm.Infrastructure.Providers.Interfaces
{
    /// <summary>
    /// Booking provider interface
    /// </summary>
    public interface IBookingProvider
    {
        /// <summary>
        /// Asynchronous method for getting all bookings
        /// </summary>
        /// <returns>List of booking entities</returns>
        Task<IEnumerable<BookingDto>> GetBookingsAsync();
    }
}