// <copyright file="ClassRoomDto.cs" company="Venkata, RALLABANDI">
// Copyright (c) Venkata, RALLABANDI. All rights reserved.
// </copyright>

namespace SchoolApp.Business.DTOs
{
    /// <summary>
    /// Data Transfer Object for a student.
    /// </summary>
    public class ClassRoomDto
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
        /// Gets or sets the location.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the students.
        /// </summary>
        public IEnumerable<StudentDto> Students { get; set; }

        /// <summary>
        /// Gets or sets the teacher.
        /// </summary>
        public TeacherDto Teacher { get; set; }
    }
}
