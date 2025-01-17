// <copyright file="GetStudentByIdHandler.cs" company="Venkata, RALLABANDI">
// Copyright (c) Venkata, RALLABANDI. All rights reserved.
// </copyright>

namespace SchoolApp.Business.Handlers.Queries
{
    using MediatR;
    using SchoolApp.Business.DTOs;
    using SchoolApp.Business.Queries.Student;
    using SchoolApp.Business.Services.Interfaces;

    /// <summary>
    /// The get student by id handler.
    /// </summary>
    public class GetStudentByIdHandler : IRequestHandler<GetStudentByIdQuery, StudentDto>
    {
        /// <summary>
        /// The student service.
        /// </summary>
        private readonly IStudentService studentService;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetStudentByIdHandler"/> class.
        /// </summary>
        /// <param name="studentService">The student service.</param>
        public GetStudentByIdHandler(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        /// <inheritdoc />
        public async Task<StudentDto> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            return await this.studentService.GetStudentByIdAsync(request.Id);
        }
    }

}
