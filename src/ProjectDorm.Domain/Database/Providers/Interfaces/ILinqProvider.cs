// <copyright file="ILinqProvider.cs" company="">
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

namespace ProjectDorm.Domain.Database.Providers.Interfaces
{
    /// <summary>
    /// Linq database provider
    /// </summary>
    public interface ILinqProvider
    {
        /// <summary>
        /// Method for accessing entities in queryable and no tracking context
        /// </summary>
        /// <typeparam name="T">Type of entity</typeparam>
        /// <returns>Queryable access to entity</returns>
        IQueryable<T> Query<T>() where T : class;
    }
}