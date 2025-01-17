// <copyright file="Teacher.cs" company="Venkata, RALLABANDI">
// Copyright (c) Venkata, RALLABANDI. All rights reserved.
// </copyright>

using Dapper.Contrib.Extensions;

namespace SchoolApp.Data.Models
{
    /// <summary>
    /// Represents a teacher in the school.
    /// </summary>
    [Table("dbo.Teacher")]
    public class Teacher : Audit
    {
        /// <summary>
        /// Gets or sets the teacher ID.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the teacher.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the subject taught by the teacher.
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Gets or sets the class room id.
        /// </summary>
        public int ClassRoomId { get; set; }
    }
}
