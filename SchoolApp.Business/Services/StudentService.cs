// <copyright file="StudentService.cs" company="Venkata, RALLABANDI">
// Copyright (c) Venkata, RALLABANDI. All rights reserved.
// </copyright>

namespace SchoolApp.Business.Services
{
    using SchoolApp.Business.DTOs;
    using SchoolApp.Business.Helpers;
    using SchoolApp.Business.Services.Interfaces;
    using SchoolApp.Data.Models;
    using SchoolApp.Data.Repositories.Interfaces;

    /// <summary>
    /// Provides services for managing students.
    /// </summary>
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="StudentService"/> class.
        /// </summary>
        /// <param name="studentRepository">The student repository.</param>
        public StudentService(IStudentRepository studentRepository)
        {
            this._studentRepository = studentRepository;
        }

        /// <summary>
        /// Adds a new student asynchronously.
        /// </summary>
        /// <param name="studentDto">The student data transfer object.</param>
        /// <param name="user">The user performing the operation.</param>
        /// <returns>The ID of the newly created student.</returns>
        public async Task<int> AddStudentAsync(StudentDto studentDto, string user)
        {
            var student = new Student
            {
                Name = studentDto.Name,
                DateOfBirth = studentDto.DateOfBirth,
                ClassRoomId = studentDto.ClassRoomId,
            };

            AuditHelper.SetAuditProperties(student, user);
            return await this._studentRepository.CreateStudentAsync(student);
        }

        /// <summary>
        /// Updates an existing student asynchronously.
        /// </summary>
        /// <param name="studentDto">The student data transfer object.</param>
        /// <param name="user">The user.</param>
        /// <returns><![CDATA[Task<bool>]]></returns>
        public async Task<bool> UpdateStudentAsync(StudentDto studentDto, string user)
        {
            var student = await this._studentRepository.GetStudentByIdAsync(studentDto.Id);
            if (student == null)
            {
                return false;
            }

            student.Name = studentDto.Name;
            student.DateOfBirth = studentDto.DateOfBirth;
            student.ClassRoomId = studentDto.ClassRoomId;
            AuditHelper.SetAuditProperties(student, user);

            return await this._studentRepository.UpdateStudentAsync(student);
        }

        /// <summary>
        /// Deletes a student asynchronously.
        /// </summary>
        /// <param name="studentId">The ID of the student to delete.</param>
        /// <returns>True if the deletion was successful; otherwise, false.</returns>
        public async Task<bool> DeleteStudentAsync(int studentId)
        {
            var student = await this._studentRepository.GetStudentByIdAsync(studentId);
            if (student == null)
            {
                return false;
            }

            return await this._studentRepository.DeleteStudentAsync(studentId);
        }

        /// <summary>
        /// Gets a student by ID asynchronously.
        /// </summary>
        /// <param name="studentId">The ID of the student to retrieve.</param>
        /// <returns>The student data transfer object.</returns>
        public async Task<StudentDto> GetStudentByIdAsync(int studentId)
        {
            var student = await this._studentRepository.GetStudentByIdAsync(studentId);
            if (student == null)
            {
                return null;
            }

            return new StudentDto
            {
                Id = student.Id,
                Name = student.Name,
                DateOfBirth = student.DateOfBirth,
                ClassRoomId = student.ClassRoomId,
            };
        }
    }
}
