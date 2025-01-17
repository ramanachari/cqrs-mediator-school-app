// <copyright file="TeacherRepository.cs" company="Venkata, RALLABANDI">
// Copyright (c) Venkata, RALLABANDI. All rights reserved.
// </copyright>

namespace SchoolApp.Data.Repositories
{
    using Dapper;
    using global::Dapper;
    using SchoolApp.Data.Models;
    using SchoolApp.Data.Repositories.Interfaces;

    /// <summary>
    /// The teacher repository.
    /// </summary>
    public class TeacherRepository : GenericRepository<Teacher>, ITeacherRepository
    {
        private readonly IDapperContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="TeacherRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public TeacherRepository(IDapperContext context)
            : base(context)
        {
            this.context = context;
        }

        /// <summary>
        /// Creates the teacher asynchronously.
        /// </summary>
        /// <param name="teacher">The teacher.</param>
        /// <returns>The ID of the created teacher.</returns>
        public async Task<int> CreateTeacherAsync(Teacher teacher)
        {
            return await this.CreateAsync(teacher);
        }

        /// <summary>
        /// Updates the teacher asynchronously.
        /// </summary>
        /// <param name="teacher">The teacher.</param>
        /// <returns>True if the update was successful; otherwise, false.</returns>
        public async Task<bool> UpdateTeacherAsync(Teacher teacher)
        {
            return await this.UpdateAsync(teacher);
        }

        /// <summary>
        /// Deletes a teacher asynchronously.
        /// </summary>
        /// <param name="teacherId">The teacher ID.</param>
        /// <returns>True if the deletion was successful; otherwise, false.</returns>
        public async Task<bool> DeleteTeacherAsync(int teacherId)
        {
            var teacher = await this.GetByIdAsync(teacherId);
            if (teacher == null)
            {
                return false;
            }

            return await this.DeleteAsync(teacherId);
        }

        /// <summary>
        /// Gets a teacher by ID asynchronously.
        /// </summary>
        /// <param name="classRoomId">The class room ID.</param>
        /// <returns>The teacher entity.</returns>
        public async Task<Teacher> GetTeacherByClassIdAsync(int classRoomId)
        {
            string query = "SELECT * FROM Teachers WHERE ClassRoomId = @ClassRoomId";
            using var conn = this.context.CreateConnection();
            var teacher = await conn.QueryFirstOrDefaultAsync<Teacher>(query, new { ClassRoomId = classRoomId });
            return teacher;
        }

        /// <summary>
        /// Gets all teachers asynchronously.
        /// </summary>
        /// <returns>A collection of teacher entities.</returns>
        public async Task<IEnumerable<Teacher>> GetAllTeachersAsync()
        {
            string query = "SELECT * FROM Teacher";
            using var conn = this.context.CreateConnection();
            var teachers = await conn.QueryAsync<Teacher>(query);
            return teachers;
        }

        /// <summary>
        /// Get teacher by id asynchronously.
        /// </summary>
        /// <param name="teacherId">The teacher id.</param>
        /// <returns><![CDATA[Task<Teacher>]]></returns>
        public async Task<Teacher> GetTeacherByIdAsync(int teacherId)
        {
            string query = "SELECT * FROM Teacher WHERE Id = @Id";
            using var conn = this.context.CreateConnection();
            var teacher = await conn.QueryFirstOrDefaultAsync<Teacher>(query, new { Id = teacherId });
            return teacher;
        }
    }
}
