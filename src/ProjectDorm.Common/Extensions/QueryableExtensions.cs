// <copyright file="QueryableExtensions.cs" company="">
// Copyright (c) 2019 All Rights Reserved
// </copyright>
// <author>Daniil Poliakh</author>
// <date>20/04/2019 7:13 PM</date>
// <summary>
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// </summary>

using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectDorm.Common.Models.Paging;

namespace ProjectDorm.Common.Extensions
{
    /// <summary>
    /// <see cref="IQueryable{T}"/> interface extensions
    /// </summary>
    public static class QueryableExtensions
    {
        /// <summary>
        /// Asynchronous method for getting paged result from database
        /// </summary>
        /// <typeparam name="T">Type of model result</typeparam>
        /// <param name="query"><see cref="IQueryable{T}"/> instance</param>
        /// <param name="page">Page number</param>
        /// <param name="size">Page size</param>
        /// <returns><see cref="PagedResult{T}"/> instance</returns>
        public static async Task<PagedResult<T>> AsPagedAsync<T>(this IQueryable<T> query, int page, int size)
        {
            var skip = (page - 1) * size;
            var take = size;

            var count = await query.CountAsync();
            var result = await query.Skip(skip).Take(take).ToListAsync();

            return new PagedResult<T>
            {
                CurrentPage = page,
                PageCount = (int)Math.Ceiling(decimal.Divide(count, size)),
                PageSize = size,
                RowCount = count,
                Result = result
            };
        }
    }
}