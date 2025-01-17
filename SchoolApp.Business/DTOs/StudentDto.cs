// <copyright file="StudentDto.cs" company="Venkata, RALLABANDI">
// Copyright (c) Venkata, RALLABANDI. All rights reserved.
// </copyright>

namespace SchoolApp.Business.DTOs
{
    /// <summary>
    /// Data Transfer Object for a student.
    /// </summary>
    public class StudentDto
    {
        /// <summary>
        /// Gets or sets the ID of the student.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the student.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the date of birth of the student.
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Gets or sets the age.
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Gets or sets the class room id.
        /// </summary>
        public int ClassRoomId { get; set; }
    }
}
