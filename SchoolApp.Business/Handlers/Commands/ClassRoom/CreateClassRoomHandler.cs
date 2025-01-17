using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Business.Handlers.Commands.ClassRoom
{
    using MediatR;
    using SchoolApp.Business.Commands.ClassRoom;
    using SchoolApp.Business.Services.Interfaces;

    public class CreateClassRoomHandler : IRequestHandler<CreateClassRoomCommand, int>
    {
        private readonly IClassRoomService _classRoomService;

        public CreateClassRoomHandler(IClassRoomService classRoomService)
        {
            _classRoomService = classRoomService;
        }

        public async Task<int> Handle(CreateClassRoomCommand request, CancellationToken cancellationToken)
        {
            return await _classRoomService.AddClassRoomAsync(request.ClassRoomDto, request.User);
        }
    }
}
