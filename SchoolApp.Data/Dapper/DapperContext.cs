// <copyright file="DapperContext.cs" company="Venkata, RALLABANDI">
// Copyright (c) Venkata, RALLABANDI. All rights reserved.
// </copyright>

namespace SchoolApp.Data.Dapper
{
    using System.Data;
    using Microsoft.Data.SqlClient;

    /// <summary>
    /// The dapper context.
    /// </summary>
    public class DapperContext : IDapperContext
    {
        /// <summary>
        /// The connection string.
        /// </summary>
        private readonly string connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="DapperContext"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        public DapperContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <inheritdoc/>
        public IDbConnection CreateConnection() => new SqlConnection(this.connectionString);
    }
}
