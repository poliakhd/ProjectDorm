// <copyright file="DateRangeDto.cs" company="">
// Copyright (c) 2019 All Rights Reserved
// </copyright>
// <author>Daniil Poliakh</author>
// <date>21/04/2019 4:05 PM</date>
// <summary>
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// </summary>

using System;

namespace ProjectDorm.Domain.Dto
{
    /// <summary>
    /// Date range data transfer object
    /// </summary>
    public class DateRangeDto
    {
        /// <summary>
        /// Gets or sets date from
        /// </summary>
        public DateTime? From { get; set; }

        /// <summary>
        /// Gets or sets date to
        /// </summary>
        public DateTime? To { get; set; }
    }
}