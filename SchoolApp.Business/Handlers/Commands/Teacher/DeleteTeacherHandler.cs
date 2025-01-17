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

    public class DeleteTeacherHandler : IRequestHandler<DeleteTeacherCommand, bool>
    {
        private readonly ITeacherService _teacherService;

        public DeleteTeacherHandler(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        public async Task<bool> Handle(DeleteTeacherCommand request, CancellationToken cancellationToken)
        {
            return await _teacherService.DeleteTeacherAsync(request.TeacherId);
        }
    }

}
