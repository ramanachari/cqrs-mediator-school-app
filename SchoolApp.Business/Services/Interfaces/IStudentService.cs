// <copyright file="IStudentService.cs" company="Venkata, RALLABANDI">
// Copyright (c) Venkata, RALLABANDI. All rights reserved.
// </copyright>

namespace SchoolApp.Business.Services.Interfaces
{
    using SchoolApp.Business.DTOs;

    /// <summary>
    /// Interface for student-related business operations.
    /// </summary>
    public interface IStudentService
    {
        /// <summary>
        /// Adds a new student.
        /// </summary>
        /// <param name="studentDto">The student DTO containing student details.</param>
        /// <param name="user">The user performing the operation.</param>
        /// <returns>The ID of the newly created student.</returns>
        Task<int> AddStudentAsync(StudentDto studentDto, string user);

        /// <summary>
        /// Updates an existing student.
        /// </summary>
        /// <param name="studentDto">The student DTO containing updated details.</param>
        /// <param name="user">The user performing the operation.</param>
        /// <returns>A boolean indicating success or failure.</returns>
        Task<bool> UpdateStudentAsync(StudentDto studentDto, string user);

        /// <summary>
        /// Deletes a student by ID.
        /// </summary>
        /// <param name="studentId">The ID of the student to delete.</param>
        /// <returns>A boolean indicating success or failure.</returns>
        Task<bool> DeleteStudentAsync(int studentId);

        /// <summary>
        /// Retrieves a student by ID.
        /// </summary>
        /// <param name="studentId">The ID of the student to retrieve.</param>
        /// <returns>The student DTO containing the student's details.</returns>
        Task<StudentDto> GetStudentByIdAsync(int studentId);
    }
}
