// <copyright file="CreateStudentHandler.cs" company="Venkata, RALLABANDI">
// Copyright (c) Venkata, RALLABANDI. All rights reserved.
// </copyright>

namespace SchoolApp.Business.Handlers.Commands.Student
{
    using MediatR;
    using SchoolApp.Business.Commands.Student;
    using SchoolApp.Business.Services.Interfaces;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The create student handler.
    /// </summary>
    public class CreateStudentHandler : IRequestHandler<CreateStudentCommand, int>
    {
        /// <summary>
        /// The student service.
        /// </summary>
        private readonly IStudentService _studentService;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateStudentHandler"/> class.
        /// </summary>
        /// <param name="studentService">The student service.</param>
        public CreateStudentHandler(IStudentService studentService)
        {
            _studentService = studentService;
        }

        /// <summary>
        /// Handle and return a task of type integer.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns><![CDATA[Task<int>]]></returns>
        public async Task<int> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.StudentDto.Name))
            {
                throw new ValidationException();
            }

            return await _studentService.AddStudentAsync(request.StudentDto, request.User);
        }
    }
}
