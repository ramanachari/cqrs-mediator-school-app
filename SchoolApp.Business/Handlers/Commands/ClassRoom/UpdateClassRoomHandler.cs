using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Business.Handlers.Commands.ClassRoom
{
    using MediatR;
    using SchoolApp.Business.Commands.ClassRoom;
    using SchoolApp.Business.Commands.Student;
    using SchoolApp.Business.Services.Interfaces;

    public class UpdateClassRoomHandler : IRequestHandler<UpdateClassRoomCommand, bool>
    {
        private readonly IClassRoomService _classRoomService;

        public UpdateClassRoomHandler(IClassRoomService classRoomService)
        {
            _classRoomService = classRoomService;
        }

        public async Task<bool> Handle(UpdateClassRoomCommand request, CancellationToken cancellationToken)
        {
            return await _classRoomService.UpdateClassRoomAsync(request.ClassRoomDto, request.User);
        }
    }
}
