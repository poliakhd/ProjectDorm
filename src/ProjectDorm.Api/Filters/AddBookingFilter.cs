// <copyright file="AddBookingFilter.cs" company="">
// Copyright (c) 2019 All Rights Reserved
// </copyright>
// <author>Daniil Poliakh</author>
// <date>20/04/2019 7:53 PM</date>
// <summary>
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// </summary>

using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace ProjectDorm.Api.Filters
{
    /// <summary>
    /// Add booking filter
    /// </summary>
    public class AddBookingFilter
    {
        /// <summary>
        /// Gets or sets room id
        /// </summary>
        [Required]
        [FromQuery]
        public int RoomId { get; set; }

        /// <summary>
        /// Gets or sets start booking date
        /// </summary>
        [Required]
        [FromQuery]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Gets or sets end booking date
        /// </summary>
        [Required]
        [FromQuery]
        public DateTime EndDate { get; set; }
    }
}