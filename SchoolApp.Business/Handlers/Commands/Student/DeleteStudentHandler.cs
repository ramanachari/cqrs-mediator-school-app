// <copyright file="DeleteStudentHandler.cs" company="Venkata, RALLABANDI">
// Copyright (c) Venkata, RALLABANDI. All rights reserved.
// </copyright>

namespace SchoolApp.Business.Handlers.Commands.Student
{
    using MediatR;
    using SchoolApp.Business.Commands.Student;
    using SchoolApp.Business.Services.Interfaces;

    /// <summary>
    /// The delete student handler.
    /// </summary>
    public class DeleteStudentHandler : IRequestHandler<DeleteStudentCommand, bool>
    {
        /// <summary>
        /// The student service.
        /// </summary>
        private readonly IStudentService studentService;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteStudentHandler"/> class.
        /// </summary>
        /// <param name="studentService">The student service.</param>
        public DeleteStudentHandler(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        /// <summary>
        /// Handle and return a task of type bool.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns><![CDATA[Task<bool>]]></returns>
        public async Task<bool> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            return await this.studentService.DeleteStudentAsync(request.StudentId);
        }
    }
}
