using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Business.Handlers.Commands.Teacher
{
    using MediatR;
    using SchoolApp.Business.Commands.Teacher;
    using SchoolApp.Business.Services.Interfaces;

    public class CreateTeacherHandler : IRequestHandler<CreateTeacherCommand, int>
    {
        private readonly ITeacherService _teacherService;

        public CreateTeacherHandler(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        public async Task<int> Handle(CreateTeacherCommand request, CancellationToken cancellationToken)
        {
            return await _teacherService.AddTeacherAsync(request.TeacherDto, request.User);
        }
    }
}
