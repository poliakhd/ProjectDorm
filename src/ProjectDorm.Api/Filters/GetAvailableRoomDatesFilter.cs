// <copyright file="GetAvailableRoomDates.cs" company="">
// Copyright (c) 2019 All Rights Reserved
// </copyright>
// <author>Daniil Poliakh</author>
// <date>21/04/2019 3:27 PM</date>
// <summary>
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// </summary>

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace ProjectDorm.Api.Filters
{
    /// <summary>
    /// Get available room dates filter
    /// </summary>
    public class GetAvailableRoomDatesFilter
    {
        /// <summary>
        /// Gets or sets room id
        /// </summary>
        [FromRoute(Name = "id")]
        [Required]
        public int Id { get; set; }
    }
}