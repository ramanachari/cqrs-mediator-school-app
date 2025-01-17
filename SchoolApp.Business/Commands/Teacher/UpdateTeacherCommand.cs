namespace SchoolApp.Business.Commands.Teacher
{
    using MediatR;
    using SchoolApp.Business.DTOs;

    /// <summary>
    /// The update teacher command.
    /// </summary>
    public class UpdateTeacherCommand : IRequest<bool>
    {
        /// <summary>
        /// Gets or sets the teacher data transfer object.
        /// </summary>
        public TeacherDto TeacherDto { get; set; }

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        public string User { get; set; }
    }
}
