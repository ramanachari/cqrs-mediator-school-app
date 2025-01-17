// <copyright file="IClassRoomRepository.cs" company="Venkata, RALLABANDI">
// Copyright (c) Venkata, RALLABANDI. All rights reserved.
// </copyright>

namespace SchoolApp.Data.Repositories.Interfaces
{
    using SchoolApp.Data.Models;

    /// <summary>
    /// Interface for Classroom repository.
    /// </summary>
    public interface IClassRoomRepository
    {
        /// <summary>
        /// Creates a new classroom asynchronously.
        /// </summary>
        /// <param name="classRoom">The classroom to be created.</param>
        /// <returns>The ID of the created classroom.</returns>
        Task<int> CreateClassRoomAsync(ClassRoom classRoom);

        /// <summary>
        /// Updates an existing classroom asynchronously.
        /// </summary>
        /// <param name="classRoom">The classroom to be updated.</param>
        /// <returns>True if the update was successful; otherwise, false.</returns>
        Task<bool> UpdateClassRoomAsync(ClassRoom classRoom);

        /// <summary>
        /// Deletes a classroom asynchronously by ID.
        /// </summary>
        /// <param name="classRoomId">The ID of the classroom to be deleted.</param>
        /// <returns>True if the deletion was successful; otherwise, false.</returns>
        Task<bool> DeleteClassRoomAsync(int classRoomId);

        /// <summary>
        /// Gets all classrooms asynchronously.
        /// </summary>
        /// <returns>A collection of all classrooms.</returns>
        Task<IEnumerable<ClassRoom>> GetAllClassRoomsAsync();

        /// <summary>
        /// Creates a new classroom asynchronously.
        /// </summary>
        /// <param name="classRoomId">The classroom ID.</param>
        /// <returns>Returns classroom.</returns>
        Task<ClassRoom> GetClassRoomsByIdAsync(int classRoomId);
    }
}
