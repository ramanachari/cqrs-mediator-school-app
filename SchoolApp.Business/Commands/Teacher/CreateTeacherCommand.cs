// <copyright file="CreateTeacherCommand.cs" company="Venkata, RALLABANDI">
// Copyright (c) Venkata, RALLABANDI. All rights reserved.
// </copyright>

namespace SchoolApp.Business.Commands.Teacher
{
    using MediatR;
    using SchoolApp.Business.DTOs;

    /// <summary>
    /// The create teacher command.
    /// </summary>
    public class CreateTeacherCommand : IRequest<int>
    {
        /// <summary>
        /// Gets or sets the teacher data transfer object.
        /// </summary>
        public TeacherDto TeacherDto { get; set; }

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        public string User { get; set; }
    }
}
