// <copyright file="PagingFilter.cs" company="">
// Copyright (c) 2019 All Rights Reserved
// </copyright>
// <author>Daniil Poliakh</author>
// <date>20/04/2019 8:49 PM</date>
// <summary>
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// </summary>

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace ProjectDorm.Api.Filters.Base
{
    /// <summary>
    /// Paging filter
    /// </summary>
    public class PagingFilter
    {
        /// <summary>
        /// Gets or sets page number
        /// </summary>
        [Required]
        [FromQuery(Name = "page")]
        public int Page { get; set; }

        /// <summary>
        /// Gets or sets page size
        /// </summary>
        [Required]
        [FromQuery(Name = "size")]
        public int Size { get; set; }
    }
}