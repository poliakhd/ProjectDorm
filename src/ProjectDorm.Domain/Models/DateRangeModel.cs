// <copyright file="DateRangeModel.cs" company="">
// Copyright (c) 2019 All Rights Reserved
// </copyright>
// <author>Daniil Poliakh</author>
// <date>21/04/2019 3:32 PM</date>
// <summary>
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// </summary>

using System;

namespace ProjectDorm.Domain.Models
{
    /// <summary>
    /// Date range model
    /// </summary>
    public class DateRangeModel
    {
        /// <summary>
        /// Gets or sets from date
        /// </summary>
        public DateTime? From { get; set; }

        /// <summary>
        /// Gets or sets to date
        /// </summary>
        public DateTime? To { get; set; }
    }
}