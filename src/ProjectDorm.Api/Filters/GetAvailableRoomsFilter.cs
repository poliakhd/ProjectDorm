// <copyright file="GetAvailableRoomsFilter.cs" company="">
// Copyright (c) 2019 All Rights Reserved
// </copyright>
// <author>Daniil Poliakh</author>
// <date>21/04/2019 7:06 PM</date>
// <summary>
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// </summary>

using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using ProjectDorm.Api.Filters.Base;

namespace ProjectDorm.Api.Filters
{
    /// <summary>
    /// Get available rooms filter
    /// </summary>
    public class GetAvailableRoomsFilter
    {
        /// <summary>
        /// Gets or sets start date
        /// </summary>
        [Required]
        [FromQuery(Name = "startDate")]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Gets or sets end date
        /// </summary>
        [Required]
        [FromQuery(Name = "endDate")]
        public DateTime EndDate { get; set; }
    }
}