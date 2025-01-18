// <copyright file="CreateStudentHandlerTests.cs" company="Venkata, RALLABANDI">
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
    /// The create student handler tests.
    /// </summary>
    [Trait("Category", "Unit")]
    public class CreateStudentHandlerTests
    {
        /// <summary>
        /// The mock student service.
        /// </summary>
        private readonly Mock<IStudentService> _mockStudentService;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateStudentHandlerTests"/> class.
        /// </summary>
        public CreateStudentHandlerTests()
        {
            _mockStudentService = new Mock<IStudentService>();
        }

        /// <summary>
        /// Handle should create student when valid data is passed.
        /// </summary>
        /// <returns>A Task</returns>
        [Fact]
        public async Task Handle_Should_CreateStudent_When_ValidDataIsPassed()
        {
            // Arrange
            var command = new CreateStudentCommand
            {
                StudentDto = new StudentDto
                {
                    Name = "Medha Sri",
                    DateOfBirth = new DateTime(2022, 06, 06),
                    ClassRoomId = 1
                },
                User = "System"
            };

            _mockStudentService.Setup(service => service.AddStudentAsync(It.IsAny<StudentDto>(), It.IsAny<string>())).ReturnsAsync(1);

            var handler = new CreateStudentHandler(_mockStudentService.Object);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.Equal(1, result);
        }

        /// <summary>
        /// Handle should throw validation exception when invalid data is passed.
        /// </summary>
        /// <returns>A Task</returns>
        [Fact]
        public async Task Handle_Should_ThrowValidationException_When_InvalidDataIsPassed()
        {
            // Arrange
            var invalidStudentDto = new StudentDto { Name = string.Empty, Age = 0 };
            var command = new CreateStudentCommand() {StudentDto = invalidStudentDto, User = "Admin" };
            var handler = new CreateStudentHandler(_mockStudentService.Object);

            // Act & Assert
            await Assert.ThrowsAsync<ValidationException>(() => handler.Handle(command, CancellationToken.None));
        }
    }
}