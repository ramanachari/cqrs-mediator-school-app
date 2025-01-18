// <copyright file="DapperContext.cs" company="Venkata, RALLABANDI">
// Copyright (c) Venkata, RALLABANDI. All rights reserved.
// </copyright>

using SchoolApp.Data.Dapper;
using System.Data;

namespace SchoolApp.Tests.Integration.Utilities
{
    /// <summary>
    /// The dapper context.
    /// </summary>
    public class DapperContext : IDapperContext
    {
        /// <summary>
        /// The db connection.
        /// </summary>
        private readonly IDbConnection dbConnection;

        /// <summary>
        /// Initializes a new instance of the <see cref="DapperContext"/> class.
        /// </summary>
        /// <param name="dbConnection">The db connection.</param>
        public DapperContext(IDbConnection dbConnection)
        {
            this.dbConnection = dbConnection;
        }

        /// <summary>
        /// Creates the connection.
        /// </summary>
        /// <returns>An IDbConnection</returns>
        public IDbConnection CreateConnection()
        {
            // Return the existing shared connection
            return this.dbConnection;
        }
    }
}
