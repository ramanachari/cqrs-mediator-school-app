// <copyright file="Student.cs" company="Venkata, RALLABANDI">
// Copyright (c) Venkata, RALLABANDI. All rights reserved.
// </copyright>

using Dapper.Contrib.Extensions;

namespace SchoolApp.Data.Models
{
    /// <summary>
    /// The student.
    /// </summary>
    [Table("dbo.Student")]
    public class Student : Audit
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the date of birth.
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Gets or sets the class room id.
        /// </summary>
        public int ClassRoomId { get; set; }
    }
}
