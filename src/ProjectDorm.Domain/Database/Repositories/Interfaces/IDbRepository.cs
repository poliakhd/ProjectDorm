// <copyright file="IDbRepository.cs" company="">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>Daniil Poliakh</author>
// <date>19/07/2018 7:43 PM</date>
// <summary>
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// </summary>

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProjectDorm.Domain.Database.Repositories.Interfaces
{
    /// <summary>
    /// Generic DbRepository contract
    /// </summary>
    /// <typeparam name="TEntity">Type of entity</typeparam>
    /// <typeparam name="TKey">Type of entity key</typeparam>
    public interface IDbRepository<TEntity, in TKey> : IDisposable
        where TEntity : class
    {
        /// <summary>
        /// Adds entity
        /// </summary>
        /// <param name="entity">Instance of entity to add</param>
        /// <returns>Instance of entity</returns>
        Task<TEntity> AddAsync(TEntity entity);

        /// <summary>
        /// Updates entity
        /// </summary>
        /// <param name="entity">Instance of entity to update</param>
        /// <returns>Instance of entity</returns>
        Task<TEntity> UpdateAsync(TEntity entity);

        /// <summary>
        /// Deletes entity
        /// </summary>
        /// <param name="entity">Instance of entity</param>
        Task DeleteAsync(TEntity entity);

        /// <summary>
        /// Gets entity async
        /// </summary>
        /// <param name="id">Entity key</param>
        /// <returns>Instance of entity</returns>
        Task<TEntity> GetAsync(TKey id);

        /// <summary>
        /// Gets all entities async
        /// </summary>
        /// <returns>Collection of entities</returns>
        Task<ICollection<TEntity>> GetAllAsync();

        /// <summary>
        /// Finds entity async
        /// </summary>
        /// <param name="match">Predicate filter</param>
        /// <returns>Instance of entity</returns>
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> match);

        /// <summary>
        /// Finds entities async
        /// </summary>
        /// <param name="match">Predicate filter</param>
        /// <returns>Collection of entities</returns>
        Task<ICollection<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> match);

        /// <summary>
        /// Counts entities async
        /// </summary>
        /// <returns>Count of entities</returns>
        Task<int> CountAsync();

        /// <summary>
        /// Save changes async
        /// </summary>
        /// <returns>Numbers of affected entities</returns>
        Task<int> SaveAsync();
    }
}