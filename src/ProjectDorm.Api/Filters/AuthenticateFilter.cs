// <copyright file="LoginDto.cs" company="">
// Copyright (c) 2019 All Rights Reserved
// </copyright>
// <author>Daniil Poliakh</author>
// <date>19/04/2019 11:47 PM</date>
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
    /// Authenticate filter
    /// </summary>
    public class AuthenticateFilter
    {
        /// <summary>
        /// Gets or sets username
        /// </summary>
        [Required]
        [FromQuery]
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets password
        /// </summary>
        [Required]
        [FromQuery]
        public string Password { get; set; }
    }
}