// <copyright file="EfDbRepository.cs" company="">
// Copyright (c) 2018 All Rights Reserved
// </copyright>
// <author>Daniil Poliakh</author>
// <date>19/07/2018 7:44 PM</date>
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
using Microsoft.EntityFrameworkCore;
using ProjectDorm.Domain.Database.Repositories.Interfaces;

namespace ProjectDorm.Domain.Database.Repositories
{
    /// <summary>
    /// EntityFramework implementation of <see cref="IDbRepository{TEntity,TKey}" />
    /// </summary>
    /// <typeparam name="TEntity">Type of entity</typeparam>
    /// <typeparam name="TKey">Type of entity key</typeparam>
    public class EfDbRepository<TEntity, TKey> : IDbRepository<TEntity, TKey>
        where TEntity : class
    {
        #region Private Members

        /// <summary>
        /// EntityFramework <see cref="DbContext" /> instance
        /// </summary>
        private readonly DbContext _context;

        /// <summary>
        /// Flag indicates that is <see cref="Dispose" /> method was called
        /// </summary>
        private bool _disposed;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="EfDbRepository{TEntity,TKey}" /> class.
        /// </summary>
        /// <param name="context"><see cref="DbContext"/> instance</param>
        public EfDbRepository(DbContext context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            var result = await _context.Set<TEntity>().AddAsync(entity);
            return result.Entity;
        }

        /// <inheritdoc />
        public virtual Task<TEntity> UpdateAsync(TEntity entity)
        {
            var result = _context.Set<TEntity>().Update(entity);
            return Task.FromResult(result.Entity);
        }

        /// <inheritdoc />
        public virtual Task DeleteAsync(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            return Task.CompletedTask;
        }

        /// <inheritdoc />
        public virtual async Task<TEntity> GetAsync(TKey id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        /// <inheritdoc />
        public virtual async Task<ICollection<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        /// <inheritdoc />
        public virtual async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> match)
        {
            return await _context.Set<TEntity>().SingleOrDefaultAsync(match);
        }

        /// <inheritdoc />
        public async Task<ICollection<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> match)
        {
            return await _context.Set<TEntity>().Where(match).ToListAsync();
        }

        /// <inheritdoc />
        public async Task<int> CountAsync()
        {
            return await _context.Set<TEntity>().CountAsync();
        }

        /// <inheritdoc />
        public virtual async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        #region Implementation of IDisposable

        /// <inheritdoc />
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposing resources
        /// </summary>
        /// <param name="disposing">Flag for distinguish what called disposing</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                    
                _disposed = true;
            }
        }

        #endregion
    }
}