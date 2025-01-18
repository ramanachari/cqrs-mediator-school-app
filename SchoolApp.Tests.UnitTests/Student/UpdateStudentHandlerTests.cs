// <copyright file="UpdateStudentHandlerTests.cs" company="Venkata, RALLABANDI">
// Copyright (c) Venkata, RALLABANDI. All rights reserved.
// </copyright>

using Moq;
using SchoolApp.Business.DTOs;
using SchoolApp.Business.Services.Interfaces;
using SchoolApp.Business.Commands.Student;
using SchoolApp.Business.Handlers.Commands.Student;
using System.ComponentModel.DataAnnotations;

namespace SchoolApp.Tests.Unit.Student
{
    /// <summary>
    /// The update student handler tests.
    /// </summary>
    [Trait("Category", "Unit")]
    public class UpdateStudentHandlerTests
    {
        /// <summary>
        /// The mock student service.
        /// </summary>
        private readonly Mock<IStudentService> _mockStudentService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateStudentHandlerTests"/> class.
        /// </summary>
        public UpdateStudentHandlerTests()
        {
            _mockStudentService = new Mock<IStudentService>();
        }

        /// <summary>
        /// Handle should update student when student exists.
        /// </summary>
        /// <returns>A Task</returns>
        [Fact]
        public async Task Handle_Should_UpdateStudent_When_StudentExists()
        {
            // Arrange
            var studentDto = new StudentDto { Id = 1, Name = "John", Age = 21 };
            var command = new UpdateStudentCommand() { StudentDto = studentDto, User = "Admin" };
            _mockStudentService.Setup(service => service.UpdateStudentAsync(It.IsAny<StudentDto>(), It.IsAny<string>())).ReturnsAsync(true);

            var handler = new UpdateStudentHandler(_mockStudentService.Object);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(result);
        }

        /// <summary>
        /// Handle should return false when student does not exist.
        /// </summary>
        /// <returns>A Task</returns>
        [Fact]
        public async Task Handle_Should_ReturnFalse_When_StudentDoesNotExist()
        {
            // Arrange
            var studentDto = new StudentDto { Id = 1, Name = "John", Age = 21 };
            var command = new UpdateStudentCommand() { StudentDto = studentDto, User = "Admin" };
            _mockStudentService.Setup(service => service.UpdateStudentAsync(It.IsAny<StudentDto>(), It.IsAny<string>())).ReturnsAsync(false);

            var handler = new UpdateStudentHandler(_mockStudentService.Object);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.False(result);
        }

        /// <summary>
        /// Handle should throw validation exception when invalid data is passed.
        /// </summary>
        /// <returns>A Task</returns>
        [Fact]
        public async Task Handle_Should_ThrowValidationException_When_InvalidDataIsPassed()
        {
            // Arrange
            var invalidStudentDto = new StudentDto { Id = 1, Name = string.Empty, Age = 0 };
            var command = new UpdateStudentCommand() { StudentDto = invalidStudentDto, User = "Admin" };
            var handler = new UpdateStudentHandler(_mockStudentService.Object);

            // Act & Assert
            await Assert.ThrowsAsync<ValidationException>(() => handler.Handle(command, CancellationToken.None));
        }
    }
}
