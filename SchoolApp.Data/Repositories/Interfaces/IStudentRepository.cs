// <copyright file="IStudentRepository.cs" company="Venkata, RALLABANDI">
// Copyright (c) Venkata, RALLABANDI. All rights reserved.
// </copyright>

namespace SchoolApp.Data.Repositories.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using SchoolApp.Data.Models;

    /// <summary>
    /// Interface for Student repository.
    /// </summary>
    public interface IStudentRepository
    {
        /// <summary>
        /// Creates a new student asynchronously.
        /// </summary>
        /// <param name="student">The student to be created.</param>
        /// <returns>The ID of the created student.</returns>
        Task<int> CreateStudentAsync(Student student);

        /// <summary>
        /// Updates an existing student asynchronously.
        /// </summary>
        /// <param name="student">The student to be updated.</param>
        /// <returns>True if the update was successful; otherwise, false.</returns>
        Task<bool> UpdateStudentAsync(Student student);

        /// <summary>
        /// Deletes a student asynchronously by ID.
        /// </summary>
        /// <param name="id">The ID of the student to be deleted.</param>
        /// <returns>True if the deletion was successful; otherwise, false.</returns>
        Task<bool> DeleteStudentAsync(int id);

        /// <summary>
        /// Gets a student by ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the student.</param>
        /// <returns>The student object.</returns>
        Task<Student> GetStudentByIdAsync(int id);

        /// <summary>
        /// Gets all students asynchronously.
        /// </summary>
        /// <returns>A collection of all students.</returns>
        Task<IEnumerable<Student>> GetAllStudentsAsync();
    }
}
