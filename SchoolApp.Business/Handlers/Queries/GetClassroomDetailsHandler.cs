// <copyright file="GetClassroomDetailsHandler.cs" company="Venkata, RALLABANDI">
// Copyright (c) Venkata, RALLABANDI. All rights reserved.
// </copyright>

namespace SchoolApp.Business.Handlers.Queries
{
    using MediatR;
    using SchoolApp.Business.DTOs;
    using SchoolApp.Business.Queries.ClassRoom;
    using SchoolApp.Business.Services.Interfaces;

    /// <summary>
    /// The get classroom details handler.
    /// </summary>
    public class GetClassroomDetailsHandler : IRequestHandler<GetClassRoomDetailsQuery, IEnumerable<ClassRoomDto>>
    {
        /// <summary>
        /// The classroom service.
        /// </summary>
        private readonly IClassRoomService classroomService;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetClassroomDetailsHandler"/> class.
        /// </summary>
        /// <param name="classroomService">The classroom service.</param>
        public GetClassroomDetailsHandler(IClassRoomService classroomService)
        {
            this.classroomService = classroomService;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<ClassRoomDto>> Handle(GetClassRoomDetailsQuery request, CancellationToken cancellationToken)
        {
            return await this.classroomService.GetClassroomDetailsAsync();
        }
    }
}
