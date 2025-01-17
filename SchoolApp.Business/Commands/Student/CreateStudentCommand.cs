// <copyright file="CreateStudentCommand.cs" company="Venkata, RALLABANDI">
// Copyright (c) Venkata, RALLABANDI. All rights reserved.
// </copyright>

namespace SchoolApp.Business.Commands.Student
{
    using MediatR;
    using SchoolApp.Business.DTOs;

    /// <summary>
    /// The create student command.
    /// </summary>
    public class CreateStudentCommand : IRequest<int>
    {
        /// <summary>
        /// Gets or sets the student data transfer object.
        /// </summary>
        public StudentDto StudentDto { get; set; }
        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        public string User { get; set; }
    }
}
