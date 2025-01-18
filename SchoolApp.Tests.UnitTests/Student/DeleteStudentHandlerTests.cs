// <copyright file="DeleteStudentHandlerTests.cs" company="Venkata, RALLABANDI">
// Copyright (c) Venkata, RALLABANDI. All rights reserved.
// </copyright>

using Moq;
using SchoolApp.Business.Services.Interfaces;
using SchoolApp.Business.Commands.Student;
using SchoolApp.Business.Handlers.Commands.Student;

namespace SchoolApp.Tests.Unit.Student
{
    /// <summary>
    /// The delete student handler tests.
    /// </summary>
    [Trait("Category", "Unit")]
    public class DeleteStudentHandlerTests
    {
        /// <summary>
        /// The mock student service.
        /// </summary>
        private readonly Mock<IStudentService> _mockStudentService;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteStudentHandlerTests"/> class.
        /// </summary>
        public DeleteStudentHandlerTests()
        {
            _mockStudentService = new Mock<IStudentService>();
        }

        /// <summary>
        /// Handle should delete student when student exists.
        /// </summary>
        /// <returns>A Task</returns>
        [Fact]
        public async Task Handle_Should_DeleteStudent_When_StudentExists()
        {
            // Arrange
            var command = new DeleteStudentCommand() { StudentId = 1 };
            _mockStudentService.Setup(service => service.DeleteStudentAsync(1)).ReturnsAsync(true);

            var handler = new DeleteStudentHandler(_mockStudentService.Object);

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
            var command = new DeleteStudentCommand() { StudentId = 1 };
            _mockStudentService.Setup(service => service.DeleteStudentAsync(1)).ReturnsAsync(false);

            var handler = new DeleteStudentHandler(_mockStudentService.Object);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.False(result);
        }
    }
}
