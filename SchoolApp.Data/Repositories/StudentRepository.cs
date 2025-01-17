// <copyright file="StudentRepository.cs" company="Venkata, RALLABANDI">
// Copyright (c) Venkata, RALLABANDI. All rights reserved.
// </copyright>

namespace SchoolApp.Data.Repositories
{
    using global::Dapper;
    using SchoolApp.Data.Dapper;
    using SchoolApp.Data.Models;
    using SchoolApp.Data.Repositories.Interfaces;

    /// <summary>
    /// The student repository.
    /// </summary>
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        private readonly IDapperContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="StudentRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public StudentRepository(IDapperContext context)
            : base(context)
        {
            this.context = context;
        }

        /// <summary>
        /// Creates the student asynchronously.
        /// </summary>
        /// <param name="student">The student.</param>
        /// <returns><![CDATA[Task<int>]]></returns>
        public async Task<int> CreateStudentAsync(Student student)
        {
            return await this.CreateAsync(student);
        }

        /// <summary>
        /// Update student asynchronously.
        /// </summary>
        /// <param name="student">The student.</param>
        /// <returns><![CDATA[Task<bool>]]></returns>
        public async Task<bool> UpdateStudentAsync(Student student)
        {
            return await this.UpdateAsync(student);
        }

        /// <summary>
        /// Deletes student asynchronously.
        /// </summary>
        /// <param name="studentId">The student id.</param>
        /// <returns><![CDATA[Task<bool>]]></returns>
        public async Task<bool> DeleteStudentAsync(int studentId)
        {
            var student = await this.GetByIdAsync(studentId);
            if (student == null)
            {
                return false;
            }

            return await this.DeleteAsync(studentId);
        }

        /// <summary>
        /// Get student by id asynchronously.
        /// </summary>
        /// <param name="studentId">The student id.</param>
        /// <returns><![CDATA[Task<Student>]]></returns>
        public async Task<Student> GetStudentByIdAsync(int studentId)
        {
            string query = "SELECT * FROM Student where Id = @Id";
            using var conn = this.context.CreateConnection();
            var student = await conn.QueryFirstOrDefaultAsync<Student>(query, new { Id = studentId });
            return student;
        }

        /// <summary>
        /// Get all students asynchronously.
        /// </summary>
        /// <returns><![CDATA[Task<IEnumerable<Student>>]]></returns>
        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            string query = "SELECT * FROM Student";
            using var conn = this.context.CreateConnection();
            var students = await conn.QueryAsync<Student>(query);
            return students;
        }
    }
}
