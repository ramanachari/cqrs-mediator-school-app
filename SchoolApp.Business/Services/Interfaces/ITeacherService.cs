// <copyright file="ITeacherService.cs" company="Venkata, RALLABANDI">
// Copyright (c) Venkata, RALLABANDI. All rights reserved.
// </copyright>

namespace SchoolApp.Business.Services.Interfaces
{

    using SchoolApp.Business.DTOs;

    /// <summary>
    /// Provides methods for managing teachers.
    /// </summary>
    public interface ITeacherService
    {
        /// <summary>
        /// Adds a new teacher asynchronously.
        /// </summary>
        /// <param name="teacherDto">The teacher data transfer object.</param>
        /// <param name="user">The user performing the operation.</param>
        /// <returns>The ID of the newly created teacher.</returns>
        Task<int> AddTeacherAsync(TeacherDto teacherDto, string user);

        /// <summary>
        /// Updates an existing teacher asynchronously.
        /// </summary>
        /// <param name="teacherDto">The teacher data transfer object.</param>
        /// <param name="user">The user performing the operation.</param>
        /// <returns>True if the update was successful; otherwise, false.</returns>
        Task<bool> UpdateTeacherAsync(TeacherDto teacherDto, string user);

        /// <summary>
        /// Deletes a teacher asynchronously.
        /// </summary>
        /// <param name="teacherId">The ID of the teacher to delete.</param>
        /// <returns>True if the deletion was successful; otherwise, false.</returns>
        Task<bool> DeleteTeacherAsync(int teacherId);

        /// <summary>
        /// Gets a teacher by ID asynchronously.
        /// </summary>
        /// <param name="teacherId">The ID of the teacher to retrieve.</param>
        /// <returns>The teacher data transfer object.</returns>
        Task<TeacherDto> GetTeacherByIdAsync(int teacherId);

        /// <summary>
        /// Gets all teachers asynchronously.
        /// </summary>
        /// <returns>A collection of teacher data transfer objects.</returns>
        Task<IEnumerable<TeacherDto>> GetAllTeachersAsync();
    }
}
