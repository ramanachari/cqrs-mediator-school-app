// <copyright file="CreateClassRoomCommand.cs" company="Venkata, RALLABANDI">
// Copyright (c) Venkata, RALLABANDI. All rights reserved.
// </copyright>

namespace SchoolApp.Business.Commands.ClassRoom
{
    using MediatR;
    using SchoolApp.Business.DTOs;

    /// <summary>
    /// The create class room command.
    /// </summary>
    public class CreateClassRoomCommand : IRequest<int>
    {
        /// <summary>
        /// Gets or sets the class room data transfer object.
        /// </summary>
        public ClassRoomDto ClassRoomDto { get; set; }

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        public string User { get; set; }
    }
}
