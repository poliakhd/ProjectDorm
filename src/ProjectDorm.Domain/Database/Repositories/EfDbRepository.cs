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
        public virtual TEntity Add(TEntity entity)
        {
            var result = _context.Set<TEntity>().Add(entity);
            return result.Entity;
        }

        /// <inheritdoc />
        public virtual TEntity Update(TEntity entity)
        {
            var result = _context.Set<TEntity>().Update(entity);
            return result.Entity;
        }

        /// <inheritdoc />
        public virtual void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        /// <inheritdoc />
        public virtual TEntity Get(TKey id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        /// <inheritdoc />
        public virtual async Task<TEntity> GetAsync(TKey id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        /// <inheritdoc />
        public IQueryable<TEntity> GetAll()
        {
            return _context.Set<TEntity>();
        }

        /// <inheritdoc />
        public virtual async Task<ICollection<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        /// <inheritdoc />
        public virtual TEntity Find(Expression<Func<TEntity, bool>> match)
        {
            return _context.Set<TEntity>().SingleOrDefault(match);
        }

        /// <inheritdoc />
        public virtual async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> match)
        {
            return await _context.Set<TEntity>().SingleOrDefaultAsync(match);
        }

        /// <inheritdoc />
        public ICollection<TEntity> FindAll(Expression<Func<TEntity, bool>> match)
        {
            return _context.Set<TEntity>().Where(match).ToList();
        }

        /// <inheritdoc />
        public async Task<ICollection<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> match)
        {
            return await _context.Set<TEntity>().Where(match).ToListAsync();
        }

        /// <inheritdoc />
        public int Count()
        {
            return _context.Set<TEntity>().Count();
        }

        /// <inheritdoc />
        public async Task<int> CountAsync()
        {
            return await _context.Set<TEntity>().CountAsync();
        }

        /// <inheritdoc />
        public virtual int Save()
        {
            return _context.SaveChanges();
        }

        /// <inheritdoc />
        public virtual async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        /// <inheritdoc />
        public virtual IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where(predicate);
        }

        /// <inheritdoc />
        public virtual async Task<ICollection<TEntity>> FindByAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().Where(predicate).ToListAsync();
        }

        /// <inheritdoc />
        public IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var queryable = GetAll();

            foreach (var includeProperty in includeProperties)
            {
                queryable = queryable.Include(includeProperty);
            }

            return queryable;
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