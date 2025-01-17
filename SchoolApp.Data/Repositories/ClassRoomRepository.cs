// <copyright file="ClassRoomRepository.cs" company="Venkata, RALLABANDI">
// Copyright (c) Venkata, RALLABANDI. All rights reserved.
// </copyright>

namespace SchoolApp.Data.Repositories
{
    using Dapper;
    using global::Dapper;
    using SchoolApp.Data.Models;
    using SchoolApp.Data.Repositories.Interfaces;

    /// <summary>
    /// The classroom repository.
    /// </summary>
    public class ClassRoomRepository : GenericRepository<ClassRoom>, IClassRoomRepository
    {
        private readonly IDapperContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClassRoomRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public ClassRoomRepository(IDapperContext context)
            : base(context)
        {
            this.context = context;
        }

        /// <summary>
        /// Creates the classroom asynchronously.
        /// </summary>
        /// <param name="classRoom">The classroom.</param>
        /// <returns>The ID of the created classroom.</returns>
        public async Task<int> CreateClassRoomAsync(ClassRoom classRoom)
        {
            return await this.CreateAsync(classRoom);
        }

        /// <summary>
        /// Updates the classroom asynchronously.
        /// </summary>
        /// <param name="classRoom">The classroom.</param>
        /// <returns>True if the update was successful; otherwise, false.</returns>
        public async Task<bool> UpdateClassRoomAsync(ClassRoom classRoom)
        {
            return await this.UpdateAsync(classRoom);
        }

        /// <summary>
        /// Deletes a classroom asynchronously.
        /// </summary>
        /// <param name="classRoomId">The classroom ID.</param>
        /// <returns>True if the deletion was successful; otherwise, false.</returns>
        public async Task<bool> DeleteClassRoomAsync(int classRoomId)
        {
            var classRoom = await this.GetByIdAsync(classRoomId);
            if (classRoom == null)
            {
                return false;
            }

            return await this.DeleteAsync(classRoomId);
        }

        /// <summary>
        /// Gets all classrooms asynchronously.
        /// </summary>
        /// <returns>A collection of classroom entities.</returns>
        public async Task<IEnumerable<ClassRoom>> GetAllClassRoomsAsync()
        {
            string query = "SELECT * FROM ClassRoom";
            using var conn = this.context.CreateConnection();
            var classRooms = await conn.QueryAsync<ClassRoom>(query);
            return classRooms;
        }

        /// <summary>
        /// Get class rooms by id asynchronously.
        /// </summary>
        /// <param name="classRoomId">The class room id.</param>
        /// <returns><![CDATA[Task<ClassRoom>]]></returns>
        public async Task<ClassRoom> GetClassRoomsByIdAsync(int classRoomId)
        {
            string query = "SELECT * FROM ClassRoom where Id = @Id";
            using var conn = this.context.CreateConnection();
            var classRoom = await conn.QueryFirstOrDefaultAsync<ClassRoom>(query, new { Id = classRoomId });
            return classRoom;
        }
    }
}
