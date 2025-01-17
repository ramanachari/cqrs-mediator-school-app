// <copyright file="ClassRoom.cs" company="Venkata, RALLABANDI">
// Copyright (c) Venkata, RALLABANDI. All rights reserved.
// </copyright>

using Dapper.Contrib.Extensions;

namespace SchoolApp.Data.Models
{
    /// <summary>
    /// Represents a classroom in the school.
    /// </summary>
    [Table("dbo.ClassRoom")]
    public class ClassRoom : Audit
    {
        /// <summary>
        /// Gets or sets the classroom ID.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the classroom.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        public string Location { get; set; }
    }
}
