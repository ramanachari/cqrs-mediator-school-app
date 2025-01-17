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

    public class DeleteClassRoomHandler : IRequestHandler<DeleteClassRoomCommand, bool>
    {
        private readonly IClassRoomService _classRoomService;

        public DeleteClassRoomHandler(IClassRoomService classRoomService)
        {
            _classRoomService = classRoomService;
        }

        public async Task<bool> Handle(DeleteClassRoomCommand request, CancellationToken cancellationToken)
        {
            return await _classRoomService.DeleteClassRoomAsync(request.ClassRoomId);
        }
    }
}
