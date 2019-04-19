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
using System.Linq;
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
        TEntity Add(TEntity entity);

        /// <summary>
        /// Updates entity
        /// </summary>
        /// <param name="entity">Instance of entity to update</param>
        /// <returns>Instance of entity</returns>
        TEntity Update(TEntity entity);

        /// <summary>
        /// Deletes entity
        /// </summary>
        /// <param name="entity">Instance of entity</param>
        void Delete(TEntity entity);

        /// <summary>
        /// Gets entity
        /// </summary>
        /// <param name="id">Entity key</param>
        /// <returns>Instance of entity</returns>
        TEntity Get(TKey id);

        /// <summary>
        /// Gets entity async
        /// </summary>
        /// <param name="id">Entity key</param>
        /// <returns>Instance of entity</returns>
        Task<TEntity> GetAsync(TKey id);

        /// <summary>
        /// Gets all entities
        /// </summary>
        /// <returns>Collection of entities</returns>
        IQueryable<TEntity> GetAll();

        /// <summary>
        /// Gets all entities async
        /// </summary>
        /// <returns>Collection of entities</returns>
        Task<ICollection<TEntity>> GetAllAsync();

        /// <summary>
        /// Finds entity
        /// </summary>
        /// <param name="match">Predicate filter</param>
        /// <returns>Instance of entity</returns>
        TEntity Find(Expression<Func<TEntity, bool>> match);

        /// <summary>
        /// Finds entity async
        /// </summary>
        /// <param name="match">Predicate filter</param>
        /// <returns>Instance of entity</returns>
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> match);

        /// <summary>
        /// Finds entities
        /// </summary>
        /// <param name="match">Predicate filter</param>
        /// <returns>Collection of entities</returns>
        ICollection<TEntity> FindAll(Expression<Func<TEntity, bool>> match);

        /// <summary>
        /// Finds entities async
        /// </summary>
        /// <param name="match">Predicate filter</param>
        /// <returns>Collection of entities</returns>
        Task<ICollection<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> match);

        /// <summary>
        /// Counts entities
        /// </summary>
        /// <returns>Count of entities</returns>
        int Count();

        /// <summary>
        /// Counts entities async
        /// </summary>
        /// <returns>Count of entities</returns>
        Task<int> CountAsync();

        /// <summary>
        /// Saves changes
        /// </summary>
        /// <returns>Numbers of affected entities</returns>
        int Save();

        /// <summary>
        /// Save changes async
        /// </summary>
        /// <returns>Numbers of affected entities</returns>
        Task<int> SaveAsync();

        /// <summary>
        /// Finds entities
        /// </summary>
        /// <param name="predicate">Filtered predicate</param>
        /// <returns>Instance of entity</returns>
        IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Finds entities async
        /// </summary>
        /// <param name="predicate">Filtered predicate</param>
        /// <returns>Collection of entities</returns>
        Task<ICollection<TEntity>> FindByAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Gets instance with include properties
        /// </summary>
        /// <param name="includeProperties">List of properties to include</param>
        /// <returns>Instance of entity with included properties</returns>
        IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] includeProperties);
    }
}