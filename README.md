# SchoolApp

SchoolApp is a .NET 8 application designed to manage various aspects of a school system, including classrooms, teachers, students. The application is structured using a clean architecture approach, separating concerns into different layers such as Business, Data, and Presentation.

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
- **Queries**: Handles read operations.
  - `ClassRoom`
  - `Teacher`
  - `Student`
- **Handlers**: Implements the logic for commands and queries.
  - `ClassRoom`
  - `Teacher`
  - `Student`
- **Services**: Contains service classes for business operations.
  - `ClassRoomService`
  - `TeacherService`
  - `StudentService`
- **DTOs**: Data Transfer Objects for transferring data between layers.
  - `ClassRoomDTO`
  - `TeacherDTO`
  - `StudentDTO`

### Data

Contains data access logic and models.

- **Models**: Entity classes representing the database schema.
  - `ClassRoom`
  - `Teacher`
  - `Student`
- **Repositories**: Repository classes for data access.
  - `ClassRoomRepository`
  - `TeacherRepository`
  - `StudentRepository`
- **Dapper**: Dapper context for database connections.
  - `DapperContext`
  - `IDapperContext`

### SchoolApp

Contains the main application logic and configuration.

- **Program.cs**: Entry point of the application.
- **Configuration**: Application settings.
  - `AppSettings`
- **DependencyInjection**: Dependency injection setup.
  - `Program`
- **(No Views)**: As this is a console-based application, we do not have a separate presentation layer with views. All interactions are handled through the console.

## Tests

This section contains **unit tests** and **integration tests** for ensuring the correctness of business logic and data access.

### Unit Tests

Unit tests focus on verifying the behavior of commands and handlers without interacting with the database. These tests ensure that the application’s core functionality works as expected.

- **CreateStudentHandlerTests**: Tests for the creation of student data.
- **DeleteStudentHandlerTests**: Tests for deleting student data.
- **UpdateStudentHandlerTests**: Tests for updating student data.
- **GetStudentByIdHandlerTests**: Tests for retrieving student data by ID.

### Integration Tests

Integration tests ensure that the data access layer (repositories) works correctly with the database, checking CRUD operations and interactions with Dapper.

- **StudentRepositoryTests**: Tests for data operations in the `StudentRepository`.

## Getting Started

To get started with the project, follow these steps:

1. Clone the repository:
    ```bash
    git clone https://github.com/ramanachari/cqrs-mediator-school-app.git
    ```
2. Navigate to the project directory:
    ```bash
    cd cqrs-mediator-school-app
    ```
3. Build the project:
    ```bash
    dotnet build
    ```
4. Run the application:
    ```bash
    dotnet run
    ```
5. Run the tests:
    ```bash
    dotnet test
    ```
    

