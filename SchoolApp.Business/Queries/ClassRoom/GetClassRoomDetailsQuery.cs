// <copyright file="GetClassroomDetailsQuery.cs" company="Venkata, RALLABANDI">
// Copyright (c) Venkata, RALLABANDI. All rights reserved.
// </copyright>

namespace SchoolApp.Business.Queries.ClassRoom
{
    using MediatR;
    using SchoolApp.Business.DTOs;

    /// <summary>
    /// The get classroom details query.
    /// </summary>
    public class GetClassRoomDetailsQuery : IRequest<IEnumerable<ClassRoomDto>>
    {
    }
}
