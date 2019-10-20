// <copyright file="PagedResult.cs" company="">
// Copyright (c) 2019 All Rights Reserved
// </copyright>
// <author>Daniil Poliakh</author>
// <date>20/04/2019 7:10 PM</date>
// <summary>
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// </summary>

using System.Collections.Generic;

namespace ProjectDorm.Common.Models.Paging
{
    /// <summary>
    /// Paged result class
    /// </summary>
    /// <typeparam name="T">Type of result list</typeparam>
    public class PagedResult<T>
    {
        /// <summary>
        /// Gets or sets current page number
        /// </summary>
        public int CurrentPage { get; set; }

        /// <summary>
        /// Gets or sets page count
        /// </summary>
        public int PageCount { get; set; }

        /// <summary>
        /// Gets or sets page size
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Gets or sets row count
        /// </summary>
        public int RowCount { get; set; }

        /// <summary>
        /// Gets or sets result list
        /// </summary>
        public ICollection<T> Result { get; set; } = new List<T>();
    }
}