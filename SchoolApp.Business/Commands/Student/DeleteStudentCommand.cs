// <copyright file="DeleteStudentCommand.cs" company="Venkata, RALLABANDI">
// Copyright (c) Venkata, RALLABANDI. All rights reserved.
// </copyright>

namespace SchoolApp.Business.Commands.Student
{
    using MediatR;

    /// <summary>
    /// The delete student command.
    /// </summary>
    public class DeleteStudentCommand : IRequest<bool>
    {
        /// <summary>
        /// Gets or sets the student id.
        /// </summary>
        public int StudentId { get; set; }
    }
}
