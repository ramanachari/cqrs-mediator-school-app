// <copyright file="TeacherService.cs" company="Venkata, RALLABANDI">
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
    /// Provides services for managing teachers.
    /// </summary>
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository teacherRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="TeacherService"/> class.
        /// </summary>
        /// <param name="teacherRepository">The teacher repository.</param>
        public TeacherService(ITeacherRepository teacherRepository)
        {
            this.teacherRepository = teacherRepository;
        }

        /// <summary>
        /// Adds a new teacher asynchronously.
        /// </summary>
        /// <param name="teacherDto">The teacher data transfer object.</param>
        /// <param name="user">The user performing the operation.</param>
        /// <returns>The ID of the newly created teacher.</returns>
        public async Task<int> AddTeacherAsync(TeacherDto teacherDto, string user)
        {
            var teacher = new Teacher
            {
                ClassRoomId = teacherDto.ClassRoomId,
                Name = teacherDto.Name,
                Subject = string.Join(",", teacherDto.Subjects),
            };

            AuditHelper.SetAuditProperties(teacher, user);
            return await this.teacherRepository.CreateTeacherAsync(teacher);
        }

        /// <summary>
        /// Updates an existing teacher asynchronously.
        /// </summary>
        /// <param name="teacherDto">The teacher data transfer object.</param>
        /// <param name="user">The user performing the operation.</param>
        /// <returns>True if the update was successful; otherwise, false.</returns>
        public async Task<bool> UpdateTeacherAsync(TeacherDto teacherDto, string user)
        {
            var teacher = await this.teacherRepository.GetTeacherByIdAsync(teacherDto.Id);
            if (teacher == null)
            {
                return false;
            }

            teacher.Name = teacherDto.Name;
            teacher.Subject = string.Join(",", teacherDto.Subjects);
            teacher.ClassRoomId = teacherDto.ClassRoomId;

            AuditHelper.SetAuditProperties(teacher, user);

            return await this.teacherRepository.UpdateTeacherAsync(teacher);
        }

        /// <summary>
        /// Deletes a teacher asynchronously.
        /// </summary>
        /// <param name="teacherId">The ID of the teacher to delete.</param>
        /// <returns>True if the deletion was successful; otherwise, false.</returns>
        public async Task<bool> DeleteTeacherAsync(int teacherId)
        {
            var teacher = await this.teacherRepository.GetTeacherByIdAsync(teacherId);
            if (teacher == null)
            {
                return false;
            }

            return await this.teacherRepository.DeleteTeacherAsync(teacherId);
        }

        /// <summary>
        /// Gets a teacher by ID asynchronously.
        /// </summary>
        /// <param name="teacherId">The ID of the teacher to retrieve.</param>
        /// <returns>The teacher data transfer object.</returns>
        public async Task<TeacherDto> GetTeacherByIdAsync(int teacherId)
        {
            var teacher = await this.teacherRepository.GetTeacherByIdAsync(teacherId);
            if (teacher == null)
            {
                return null;
            }

            return new TeacherDto
            {
                Id = teacher.Id,
                Name = teacher.Name,
                Subjects = teacher.Subject.Split(","),
            };
        }

        /// <summary>
        /// Gets all teachers asynchronously.
        /// </summary>
        /// <returns>A collection of teacher data transfer objects.</returns>
        public async Task<IEnumerable<TeacherDto>> GetAllTeachersAsync()
        {
            var teachers = await this.teacherRepository.GetAllTeachersAsync();
            var teacherDtos = new List<TeacherDto>();

            foreach (var teacher in teachers)
            {
                teacherDtos.Add(new TeacherDto
                {
                    Id = teacher.Id,
                    Name = teacher.Name,
                    Subjects = teacher.Subject.Split(","),
                });
            }

            return teacherDtos;
        }
    }
}
