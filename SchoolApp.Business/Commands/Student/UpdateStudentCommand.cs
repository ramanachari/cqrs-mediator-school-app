namespace SchoolApp.Business.Commands.Student
{
    using MediatR;
    using SchoolApp.Business.DTOs;

    /// <summary>
    /// The update student command.
    /// </summary>
    public class UpdateStudentCommand : IRequest<bool>
    {
        /// <summary>
        /// Gets or sets the student data transfer object.
        /// </summary>
        public StudentDto StudentDto { get; set; }
        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        public string User { get; set; }
    }
}
