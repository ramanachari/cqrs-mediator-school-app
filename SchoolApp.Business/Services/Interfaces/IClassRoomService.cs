// <copyright file="IClassRoomService.cs" company="Venkata, RALLABANDI">
// Copyright (c) Venkata, RALLABANDI. All rights reserved.
// </copyright>

namespace SchoolApp.Business.Services.Interfaces
{
    using SchoolApp.Business.DTOs;

    /// <summary>
    /// Provides methods for managing classrooms.
    /// </summary>
    public interface IClassRoomService
    {
        /// <summary>
        /// Adds a new classroom asynchronously.
        /// </summary>
        /// <param name="classRoomDto">The classroom data transfer object.</param>
        /// <param name="user">The user performing the operation.</param>
        /// <returns>The ID of the newly created classroom.</returns>
        Task<int> AddClassRoomAsync(ClassRoomDto classRoomDto, string user);

        /// <summary>
        /// Updates an existing classroom asynchronously.
        /// </summary>
        /// <param name="classRoomDto">The classroom data transfer object.</param>
        /// <param name="user">The user performing the operation.</param>
        /// <returns>True if the update was successful; otherwise, false.</returns>
        Task<bool> UpdateClassRoomAsync(ClassRoomDto classRoomDto, string user);

        /// <summary>
        /// Deletes a classroom asynchronously.
        /// </summary>
        /// <param name="classRoomId">The ID of the classroom to delete.</param>
        /// <returns>True if the deletion was successful; otherwise, false.</returns>
        Task<bool> DeleteClassRoomAsync(int classRoomId);

        /// <summary>
        /// Gets all classrooms asynchronously.
        /// </summary>
        /// <returns>A collection of classroom data transfer objects.</returns>
        Task<IEnumerable<ClassRoomDto>> GetAllClassRoomsAsync();

        /// <summary>
        /// Gets all classroom details asynchronously.
        /// </summary>
        /// <returns>A collection of classroom data transfer objects.</returns>
        Task<IEnumerable<ClassRoomDto>> GetClassroomDetailsAsync();
    }
}
