// <copyright file="GetStudentByIdQuery.cs" company="Venkata, RALLABANDI">
// Copyright (c) Venkata, RALLABANDI. All rights reserved.
// </copyright>

namespace SchoolApp.Business.Queries.Student
{
    using MediatR;
    using SchoolApp.Business.DTOs;

    /// <summary>
    /// The get student by id query.
    /// </summary>
    public class GetStudentByIdQuery : IRequest<StudentDto>
    {
        /// <summary>
        /// Gets or sets the student ID.
        /// </summary>
        public int Id { get; set; }
    }
}
