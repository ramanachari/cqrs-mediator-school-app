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

1. **Clone the Repository**  
   Clone the repository to your local machine:
   ```bash
   git clone https://github.com/ramanachari/cqrs-mediator-school-app.git
2. **Navigate to the Project Directory**  
   ```bash
   cd cqrs-mediator-school-app
3. **Build the Project**  
   Build the project using the following command:
   ```bash
   dotnet build
4. **Run the Application**  
   ```bash
   dotnet run
5. **Run the Tests**  
   Run the unit and integration tests:
   ```bash
   dotnet test

