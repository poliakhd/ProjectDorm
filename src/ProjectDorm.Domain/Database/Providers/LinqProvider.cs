// <copyright file="LinqProvider.cs" company="">
// Copyright (c) 2019 All Rights Reserved
// </copyright>
// <author>Daniil Poliakh</author>
// <date>19/04/2019 10:33 PM</date>
// <summary>
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// </summary>

using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProjectDorm.Domain.Database.Providers.Interfaces;

namespace ProjectDorm.Domain.Database.Providers
{
    /// <inheritdoc />
    public class LinqProvider : ILinqProvider
    {
        private readonly AppDbContext _dbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="LinqProvider" /> class.
        /// </summary>
        public LinqProvider(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        /// <inheritdoc />
        public IQueryable<T> Query<T>()
            where T : class
        {
            return _dbContext.Set<T>()
                .AsNoTracking()
                .AsQueryable();
        }
    }
}