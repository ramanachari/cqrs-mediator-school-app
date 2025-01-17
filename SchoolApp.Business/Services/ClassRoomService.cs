// <copyright file="ClassRoomService.cs" company="Venkata, RALLABANDI">
// Copyright (c) Venkata, RALLABANDI. All rights reserved.
// </copyright>

namespace SchoolApp.Business.Services
{
    using System.Collections.Generic;
    using SchoolApp.Business.DTOs;
    using SchoolApp.Business.Helpers;
    using SchoolApp.Business.Services.Interfaces;
    using SchoolApp.Data.Models;
    using SchoolApp.Data.Repositories.Interfaces;

    /// <summary>
    /// Provides services for managing classrooms.
    /// </summary>
    public class ClassRoomService : IClassRoomService
    {
        private readonly IClassRoomRepository classRoomRepository;
        private readonly IStudentRepository studentRepository;
        private readonly ITeacherRepository teacherRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClassRoomService"/> class.
        /// </summary>
        /// <param name="classRoomRepository">The classroom repository.</param>
        /// <param name="teacherRepository">The teacher repository.</param>
        /// <param name="studentRepository">The student repository.</param>
        public ClassRoomService(
            IClassRoomRepository classRoomRepository,
            ITeacherRepository teacherRepository,
            IStudentRepository studentRepository)
        {
            this.classRoomRepository = classRoomRepository;
            this.studentRepository = studentRepository;
            this.teacherRepository = teacherRepository;
        }

        /// <summary>
        /// Adds a new classroom asynchronously.
        /// </summary>
        /// <param name="classRoomDto">The classroom data transfer object.</param>
        /// <param name="user">The user performing the operation.</param>
        /// <returns>The ID of the newly created classroom.</returns>
        public async Task<int> AddClassRoomAsync(ClassRoomDto classRoomDto, string user)
        {
            var classRoom = new ClassRoom
            {
                Name = classRoomDto.Name,
                Location = classRoomDto.Location,
            };

            AuditHelper.SetAuditProperties(classRoom, user);
            return await this.classRoomRepository.CreateClassRoomAsync(classRoom);
        }

        /// <summary>
        /// Updates an existing classroom asynchronously.
        /// </summary>
        /// <param name="classRoomDto">The classroom data transfer object.</param>
        /// <param name="user">The user performing the operation.</param>
        /// <returns>True if the update was successful; otherwise, false.</returns>
        public async Task<bool> UpdateClassRoomAsync(ClassRoomDto classRoomDto, string user)
        {
            var classRoom = await this.classRoomRepository.GetClassRoomsByIdAsync(classRoomDto.Id);
            if (classRoom == null)
            {
                return false;
            }

            classRoom.Name = classRoomDto.Name;
            classRoom.Location = classRoomDto.Location;
            AuditHelper.SetAuditProperties(classRoom, user);

            return await this.classRoomRepository.UpdateClassRoomAsync(classRoom);
        }

        /// <summary>
        /// Deletes a classroom asynchronously.
        /// </summary>
        /// <param name="classRoomId">The ID of the classroom to delete.</param>
        /// <returns>True if the deletion was successful; otherwise, false.</returns>
        public async Task<bool> DeleteClassRoomAsync(int classRoomId)
        {
            var classRoom = await this.classRoomRepository.GetClassRoomsByIdAsync(classRoomId);
            if (classRoom == null)
            {
                return false;
            }

            return await this.classRoomRepository.DeleteClassRoomAsync(classRoomId);
        }

        /// <summary>
        /// Gets all classrooms asynchronously.
        /// </summary>
        /// <returns>A collection of classroom data transfer objects.</returns>
        public async Task<IEnumerable<ClassRoomDto>> GetAllClassRoomsAsync()
        {
            var classRooms = await this.classRoomRepository.GetAllClassRoomsAsync();
            var classRoomDtos = new List<ClassRoomDto>();

            foreach (var classRoom in classRooms)
            {
                classRoomDtos.Add(new ClassRoomDto
                {
                    Id = classRoom.Id,
                    Name = classRoom.Name,
                    Location = classRoom.Location,
                });
            }

            return classRoomDtos;
        }

        /// <summary>
        /// Get classroom details asynchronously.
        /// </summary>
        /// <returns><![CDATA[Task<IEnumerable<ClassRoomDto>>]]></returns>
        public async Task<IEnumerable<ClassRoomDto>> GetClassroomDetailsAsync()
        {
            var classrooms = await this.classRoomRepository.GetAllClassRoomsAsync();
            if (classrooms is not null && !classrooms.Any())
            {
                return [];
            }

            var students = await this.studentRepository.GetAllStudentsAsync();
            var teachers = await this.teacherRepository.GetAllTeachersAsync();
            List<ClassRoomDto> classRoomDtos = new();
            foreach (var classRoom in classrooms)
            {
                var teacher = teachers.FirstOrDefault(t => t.ClassRoomId == classRoom.Id);
                classRoomDtos.Add(new ClassRoomDto
                {
                    Id = classRoom.Id,
                    Name = classRoom.Name,
                    Location = classRoom.Location,
                    Students = students.Where(s => s.ClassRoomId == classRoom.Id).Select(s => new StudentDto
                    {
                        Id = s.Id,
                        Name = s.Name,
                        Age = this.CalculateAge(s.DateOfBirth),
                        DateOfBirth = s.DateOfBirth,
                    }).ToList(),
                    Teacher = new TeacherDto
                    {
                        Id = teacher.Id,
                        Name = teacher.Name,
                        Subject = teacher.Subject,
                    },
                });
            }

            return classRoomDtos;
        }

        private int CalculateAge(DateTime dateOfBirth)
        {
            var age = DateTime.Now.Year - dateOfBirth.Year;
            if (DateTime.Now < dateOfBirth.AddYears(age))
            {
                age--;
            }

            return age;
        }
    }
}
