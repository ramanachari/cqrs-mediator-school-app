// <copyright file="DeleteTeacherCommand.cs" company="Venkata, RALLABANDI">
// Copyright (c) Venkata, RALLABANDI. All rights reserved.
// </copyright>

namespace SchoolApp.Business.Commands.Teacher
{
    using MediatR;

    /// <summary>
    /// The delete teacher command.
    /// </summary>
    public class DeleteTeacherCommand : IRequest<bool>
    {
        /// <summary>
        /// Gets or sets the teacher id.
        /// </summary>
        public int TeacherId { get; set; }
    }
}
