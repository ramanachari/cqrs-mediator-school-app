// <copyright file="ITeacherRepository.cs" company="Venkata, RALLABANDI">
// Copyright (c) Venkata, RALLABANDI. All rights reserved.
// </copyright>

namespace SchoolApp.Data.Repositories.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using SchoolApp.Data.Models;

    /// <summary>
    /// Interface for Teacher repository.
    /// </summary>
    public interface ITeacherRepository
    {
        /// <summary>
        /// Creates a new teacher asynchronously.
        /// </summary>
        /// <param name="teacher">The teacher to be created.</param>
        /// <returns>The ID of the created teacher.</returns>
        Task<int> CreateTeacherAsync(Teacher teacher);

        /// <summary>
        /// Updates an existing teacher asynchronously.
        /// </summary>
        /// <param name="teacher">The teacher to be updated.</param>
        /// <returns>True if the update was successful; otherwise, false.</returns>
        Task<bool> UpdateTeacherAsync(Teacher teacher);

        /// <summary>
        /// Deletes a teacher asynchronously by ID.
        /// </summary>
        /// <param name="teacherId">The ID of the teacher to be deleted.</param>
        /// <returns>True if the deletion was successful; otherwise, false.</returns>
        Task<bool> DeleteTeacherAsync(int teacherId);

        /// <summary>
        /// Gets a teacher by ID asynchronously.
        /// </summary>
        /// <param name="teacherId">The ID of the teacher.</param>
        /// <returns>The teacher object.</returns>
        Task<Teacher> GetTeacherByClassIdAsync(int teacherId);

        /// <summary>
        /// Gets all teachers asynchronously.
        /// </summary>
        /// <returns>A collection of all teachers.</returns>
        Task<IEnumerable<Teacher>> GetAllTeachersAsync();

        /// <summary>
        /// Gets teachers asynchronously by ID.
        /// </summary>
        /// <param name="teacherId">The ID of the teacher.</param>
        /// <returns>Get teacher by Id.</returns>
        Task<Teacher> GetTeacherByIdAsync(int teacherId);
    }
}
