// <copyright file="UpdateStudentHandler.cs" company="Venkata RALLABANDI">
// Copyright (c) Venkata RALLABANDI. All rights reserved.
// </copyright>

namespace SchoolApp.Business.Handlers.Commands.Student
{
    using MediatR;
    using SchoolApp.Business.Commands.Student;
    using SchoolApp.Business.Services.Interfaces;

    /// <summary>
    /// The update student handler.
    /// </summary>
    public class UpdateStudentHandler : IRequestHandler<UpdateStudentCommand, bool>
    {
        /// <summary>
        /// The student service.
        /// </summary>
        private readonly IStudentService _studentService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateStudentHandler"/> class.
        /// </summary>
        /// <param name="studentService">The student service.</param>
        public UpdateStudentHandler(IStudentService studentService)
        {
            _studentService = studentService;
        }

        /// <summary>
        /// Handle and return a task of type bool.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns><![CDATA[Task<bool>]]></returns>
        public async Task<bool> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            return await _studentService.UpdateStudentAsync(request.StudentDto, request.User);
        }
    }
}
