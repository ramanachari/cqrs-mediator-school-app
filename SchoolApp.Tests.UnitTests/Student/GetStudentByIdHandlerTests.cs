// <copyright file="GetStudentByIdHandlerTests.cs" company="Venkata, RALLABANDI">
// Copyright (c) Venkata, RALLABANDI. All rights reserved.
// </copyright>

using Moq;
using SchoolApp.Business.DTOs;
using SchoolApp.Business.Handlers.Queries;
using SchoolApp.Business.Services.Interfaces;
using SchoolApp.Business.Queries.Student;

namespace SchoolApp.Tests.Unit.Student
{
    /// <summary>
    /// The get student by id handler tests.
    /// </summary>
    [Trait("Category", "Unit")]
    public class GetStudentByIdHandlerTests
    {
        /// <summary>
        /// The mock student service.
        /// </summary>
        private readonly Mock<IStudentService> _mockStudentService;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetStudentByIdHandlerTests"/> class.
        /// </summary>
        public GetStudentByIdHandlerTests()
        {
            _mockStudentService = new Mock<IStudentService>();
        }

        /// <summary>
        /// Handle should return student when student exists.
        /// </summary>
        /// <returns>A Task</returns>
        [Fact]
        public async Task Handle_Should_ReturnStudent_When_StudentExists()
        {
            // Arrange
            var studentDto = new StudentDto { Id = 1, Name = "John", Age = 20 };
            var query = new GetStudentByIdQuery
            {
                Id = studentDto.Id,
            };
            _mockStudentService.Setup(service => service.GetStudentByIdAsync(1)).ReturnsAsync(studentDto);

            var handler = new GetStudentByIdHandler(_mockStudentService.Object);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.Equal(studentDto, result);
        }

        /// <summary>
        /// Handle should return null when student does not exist.
        /// </summary>
        /// <returns>A Task</returns>
        [Fact]
        public async Task Handle_Should_ReturnNull_When_StudentDoesNotExist()
        {
            // Arrange
            var query = new GetStudentByIdQuery
            {
                Id = 1
            };
            _mockStudentService.Setup(service => service.GetStudentByIdAsync(1)).ReturnsAsync((StudentDto)null);

            var handler = new GetStudentByIdHandler(_mockStudentService.Object);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.Null(result);
        }
    }
}
