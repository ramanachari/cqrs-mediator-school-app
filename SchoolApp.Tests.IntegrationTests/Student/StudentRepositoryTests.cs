// <copyright file="StudentRepositoryIntegrationTests.cs" company="Venkata, RALLABANDI">
// Copyright (c) Venkata, RALLABANDI. All rights reserved.
// </copyright>

namespace SchoolApp.Tests.Integration.Student
{
    using System.Data;
    using Microsoft.Data.Sqlite;
    using System;
    using Dapper;
    using SchoolApp.Data.Dapper;
    using Xunit;
    using System.Data.SQLite;
    using DapperContext = Utilities.DapperContext;
    using SchoolApp.Data.Repositories;

    /// <summary>
    /// The student repository integration tests.
    /// </summary>
    public class StudentRepositoryIntegrationTests
    {
        /// <summary>
        /// The db connection.
        /// </summary>
        private readonly IDbConnection dbConnection;
        /// <summary>
        /// The dapper context.
        /// </summary>
        private readonly IDapperContext dapperContext;
        /// <summary>
        /// The student repository.
        /// </summary>
        private readonly StudentRepository studentRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="StudentRepositoryIntegrationTests"/> class.
        /// </summary>
        public StudentRepositoryIntegrationTests()
        {
            // Setup an in-memory SQLite database
            dbConnection = new SQLiteConnection("Data Source=:memory:");
            dbConnection.Open();

            // Create the ClassRoom table
            string createClassRoomTableQuery = @"
            CREATE TABLE ClassRoom (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Name TEXT NOT NULL
            );";
            dbConnection.Execute(createClassRoomTableQuery);

            // Create the Student table
            string createStudentTableQuery = @"
            CREATE TABLE Student (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Name TEXT NOT NULL,
                DateOfBirth TEXT NOT NULL,
                ClassRoomId INTEGER NOT NULL,
                CreatedDate TEXT NOT NULL,
                UpdatedDate TEXT NOT NULL,
                CreatedBy TEXT NOT NULL,
                UpdatedBy TEXT NOT NULL,
                FOREIGN KEY (ClassRoomId) REFERENCES ClassRoom(Id) ON DELETE CASCADE
            );";
            dbConnection.Execute(createStudentTableQuery);

            // Use DapperContext and StudentRepository
            dapperContext = new DapperContext(dbConnection);
            studentRepository = new StudentRepository(dapperContext);
        }

        /// <summary>
        /// Get student by id asynchronously should return student when student exists.
        /// </summary>
        /// <returns>A Task</returns>
        [Fact]
        public async Task GetStudentByIdAsync_ShouldReturnStudent_WhenStudentExists()
        {
            // Arrange: Insert a test classroom
            string insertClassRoomQuery = "INSERT INTO ClassRoom (Name) VALUES (@Name); SELECT last_insert_rowid();";
            int classRoomId = dbConnection.ExecuteScalar<int>(insertClassRoomQuery, new { Name = "Math Class" });

            // Insert a test student
            string insertQuery = @"
            INSERT INTO Student (Name, DateOfBirth, ClassRoomId, CreatedDate, UpdatedDate, CreatedBy, UpdatedBy) 
            VALUES (@Name, @DateOfBirth, @ClassRoomId, @CreatedDate, @UpdatedDate, @CreatedBy, @UpdatedBy); 
            SELECT last_insert_rowid();";

            int studentId = dbConnection.ExecuteScalar<int>(insertQuery, new
            {
                Name = "John Doe",
                DateOfBirth = "2000-01-01",
                ClassRoomId = classRoomId,
                CreatedDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                UpdatedDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                CreatedBy = "admin",
                UpdatedBy = "admin"
            });

            // Act: Retrieve the student by ID
            var student = await studentRepository.GetStudentByIdAsync(studentId);

            // Assert: Verify the retrieved data
            Assert.NotNull(student);
            Assert.Equal(studentId, student.Id);
            Assert.Equal("John Doe", student.Name);
            Assert.Equal("2000-01-01", student.DateOfBirth.ToString("yyyy-MM-dd"));
            Assert.Equal(classRoomId, student.ClassRoomId);
        }

        /// <summary>
        /// Get student by id asynchronously should return null when student does not exist.
        /// </summary>
        /// <returns>A Task</returns>
        [Fact]
        public async Task GetStudentByIdAsync_ShouldReturnNull_WhenStudentDoesNotExist()
        {
            // Act: Try to get a non-existing student
            var student = await studentRepository.GetStudentByIdAsync(999); // ID that doesn't exist

            // Assert: The student should be null
            Assert.Null(student);
        }
    }
}



