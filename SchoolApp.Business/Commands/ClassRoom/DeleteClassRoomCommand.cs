// <copyright file="DeleteClassRoomCommand.cs" company="Venkata, RALLABANDI">
// Copyright (c) Venkata, RALLABANDI. All rights reserved.
// </copyright>

namespace SchoolApp.Business.Commands.Student
{
    using MediatR;

    /// <summary>
    /// The delete class room command.
    /// </summary>
    public class DeleteClassRoomCommand : IRequest<bool>
    {
        /// <summary>
        /// Gets or sets the class room id.
        /// </summary>
        public int ClassRoomId { get; set; }
    }
}
