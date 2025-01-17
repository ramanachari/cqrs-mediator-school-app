// <copyright file="TeacherDto.cs" company="Venkata, RALLABANDI">
// Copyright (c) Venkata, RALLABANDI. All rights reserved.
// </copyright>

namespace SchoolApp.Business.DTOs
{
    /// <summary>
    /// Data Transfer Object for a student.
    /// </summary>
    public class TeacherDto
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
        /// Gets or sets the subject taught by the teacher.
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Gets or sets the subjects.
        /// </summary>
        public IEnumerable<string> Subjects { get; set; }

        /// <summary>
        /// Gets or sets the class room id.
        /// </summary>
        public int ClassRoomId { get; set; }
    }
}
