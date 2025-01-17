// <copyright file="GenericRepository.cs" company="Venkata, RALLABANDI">
// Copyright (c) Venkata, RALLABANDI. All rights reserved.
// </copyright>

using Dapper.Contrib.Extensions;
using SchoolApp.Data.Dapper;

namespace SchoolApp.Data.Repositories
{
    /// <summary>
    /// The generic repository.
    /// </summary>
    /// <typeparam name="T">Generic class.</typeparam>
    public class GenericRepository<T>
        where T : class
    {
        /// <summary>
        /// The this.context.
        /// </summary>
        private readonly IDapperContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericRepository{T}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public GenericRepository(IDapperContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Creates and return a task of type integer asynchronously.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns><![CDATA[Task<int>]]></returns>
        public async Task<int> CreateAsync(T entity)
        {
            using var connection = this.context.CreateConnection();
            return await connection.InsertAsync(entity); // Dapper.Contrib InsertAsync
        }

        /// <summary>
        /// Update and return a task of type bool asynchronously.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns><![CDATA[Task<bool>]]></returns>
        public async Task<bool> UpdateAsync(T entity)
        {
            using var connection = this.context.CreateConnection();
            return await connection.UpdateAsync(entity); // Dapper.Contrib UpdateAsync
        }

        /// <summary>
        /// Deletes and return a task of type bool asynchronously.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns><![CDATA[Task<bool>]]></returns>
        public async Task<bool> DeleteAsync(int id)
        {
            using var connection = this.context.CreateConnection();
            var entity = await connection.GetAsync<T>(id); // Dapper.Contrib GetAsync
            if (entity != null)
            {
                return await connection.DeleteAsync(entity); // Dapper.Contrib DeleteAsync
            }
            return false;
        }

        /// <summary>
        /// Get by id asynchronously.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns><![CDATA[Task<T>]]></returns>
        public async Task<T> GetByIdAsync(int id)
        {
            using var connection = this.context.CreateConnection();
            return await connection.GetAsync<T>(id); // Dapper.Contrib GetAsync
        }

        /// <summary>
        /// Get the all asynchronously.
        /// </summary>
        /// <returns><![CDATA[Task<IEnumerable<T>>]]></returns>
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            using var connection = this.context.CreateConnection();
            return await connection.GetAllAsync<T>(); // Dapper.Contrib GetAllAsync
        }
    }
}
