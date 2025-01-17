// <copyright file="IDapperContext.cs" company="Venkata, RALLABANDI">
// Copyright (c) Venkata, RALLABANDI. All rights reserved.
// </copyright>

namespace SchoolApp.Data.Dapper
{
    using System.Data;

    public interface IDapperContext
    {
        IDbConnection CreateConnection();
    }
}
