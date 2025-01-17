# SchoolApp

SchoolApp is a .NET 8 application designed to manage various aspects of a school system, including classrooms, teachers, students, and schools. The application is structured using a clean architecture approach, separating concerns into different layers such as Business, Data, and Presentation.

## Technologies Used

- **.NET 8**
- **C# 12.0**
- **Dapper** for data access
- **Unit Testing** with xUnit
- **Integration Testing** with xUnit

## Project Structure

The project is organized into several key directories:

### Business

Contains the core business logic of the application.

- **Commands**: Handles create, update, and delete operations.
  - `ClassRoom`
  - `Teacher`
  - `Student`
  - `School`
- **Queries**: Handles read operations.
  - `ClassRoom`
  - `Teacher`
  - `Student`
  - `School`
- **Handlers**: Implements the logic for commands and queries.
  - `ClassRoom`
  - `Teacher`
  - `Student`
  - `School`
- **Services**: Contains service classes for business operations.
  - `ClassRoomService`
  - `TeacherService`
  - `StudentService`
  - `SchoolService`
- **DTOs**: Data Transfer Objects for transferring data between layers.
  - `ClassRoomDTO`
  - `TeacherDTO`
  - `StudentDTO`
  - `SchoolDTO`

### Data

Contains data access logic and models.

- **Models**: Entity classes representing the database schema.
  - `ClassRoom`
  - `Teacher`
  - `Student`
  - `School`
- **Repositories**: Repository classes for data access.
  - `ClassRoomRepository`
  - `TeacherRepository`
  - `StudentRepository`
  - `SchoolRepository`
- **Dapper**: Dapper context for database connections.
  - `DapperContext`
  - `IDapperContext`

### SchoolApp

Contains the main application logic and configuration.

- **Program.cs**: Entry point of the application.
- **Configuration**: Application settings.
  - `AppSettings`
- **DependencyInjection**: Dependency injection setup.
  - `Startup`
- **Views**: Presentation layer classes.
  - `SchoolView`
  - `ClassRoomView`
  - `TeacherView`
  - `StudentView`

### Tests

Contains unit and integration tests.

- **UnitTests**: Unit tests for commands, queries, and services.
  - `ClassRoomCommandTests`
  - `ClassRoomQueryTests`
  - `ClassRoomServiceTests`
- **IntegrationTests**: Integration tests for database interactions.
  - `ClassRoomRepositoryTests`
- **TestUtilities**: Helper classes for testing.
  - `TestHelper`

## Getting Started

To get started with the project, follow these steps:

1. Clone the repository:
2. Navigate to the project directory:
3. Build the project:
4. Run the application:
5. Run the tests:
