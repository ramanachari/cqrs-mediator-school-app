// <copyright file="StudentService.cs" company="Venkata, RALLABANDI">
// Copyright (c) Venkata, RALLABANDI. All rights reserved.
// </copyright>

using MediatR;
using SchoolApp.Business.Commands.Student;
using SchoolApp.Business.DTOs;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SchoolApp.Data.Dapper;
using SchoolApp.Data.Repositories.Interfaces;
using SchoolApp.Data.Repositories;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using SchoolApp.Business.Services.Interfaces;
using SchoolApp.Business.Services;
using SchoolApp.Client.Utilities;
using SchoolApp.Business.Commands.ClassRoom;
using SchoolApp.Business.Commands.Teacher;
using SchoolApp.Business.Queries.Student;
using SchoolApp.Business.Queries.ClassRoom;


var host = Host.CreateDefaultBuilder(args)
.ConfigureAppConfiguration((context, config) =>
{
    config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
})
.ConfigureServices((context, services) =>
{
    var connectionString = context.Configuration.GetConnectionString("SchoolConnectionString");
    services.AddMediatR(Assembly.GetAssembly(typeof(CreateStudentCommand)));
    services.AddMediatR(Assembly.GetAssembly(typeof(GetStudentByIdQuery)));
    services.AddMediatR(typeof(Program));
    services.AddSingleton<IDapperContext>(new DapperContext(connectionString));
    services.AddTransient<IStudentRepository, StudentRepository>();
    services.AddTransient<IStudentService, StudentService>();
    services.AddTransient<ITeacherRepository, TeacherRepository>();
    services.AddTransient<ITeacherService, TeacherService>();
    services.AddTransient<IClassRoomRepository, ClassRoomRepository>();
    services.AddTransient<IClassRoomService, ClassRoomService>();
})
.Build();

var mediator = host.Services.GetRequiredService<IMediator>();


await GlobalExceptionHandler.Handle(async () =>
{
    //   We have only one school and School name is hardcoded in the application.
    //We can Similarly have a School table and get the School name from the table.

    //ClassRoom has many Students and single Teacher.
    //Teacher
    //Student

    //Add Classroom
    var classroomId = await mediator.Send(new CreateClassRoomCommand
    {
        ClassRoomDto = new ClassRoomDto
        {
            Name = "U.G",
            Location = "Narasaraopet, Andhra Pradesh, India",
        },
        User = "System",
    });

    var createCommand = new CreateStudentCommand
    {
        StudentDto = new StudentDto
        {
            Name = "Jane Smith",
            DateOfBirth = new DateTime(2008, 8, 15),
            ClassRoomId = classroomId,
        },
        User = "Admin"
    };
    var newStudentId = await mediator.Send(createCommand);
    Console.WriteLine($"Created Student ID: {newStudentId}");

    var studentQuery = new GetStudentByIdQuery
    {
        Id = newStudentId
    };

    var student = await mediator.Send(studentQuery);
    Console.WriteLine($"Student Created: {student.Id} {student.Name} : {student.DateOfBirth.ToShortDateString()}");

    // Update the student
    var updateCommand = new UpdateStudentCommand
    {
        StudentDto = new StudentDto
        {
            Id = newStudentId,
            Name = "Jane Doe",
            DateOfBirth = new DateTime(2009, 1, 2),
            ClassRoomId = classroomId,
        },
        User = "Admin"
    };
    var updated = await mediator.Send(updateCommand);
    Console.WriteLine(updated ? "Student updated successfully" : "Update failed");
    student = await mediator.Send(studentQuery);
    Console.WriteLine($"Student Updated: {student.Id} {student.Name} : {student.DateOfBirth.ToShortDateString()}");
    // Delete the student
    var deleteCommand = new DeleteStudentCommand { StudentId = newStudentId };
    var deleted = await mediator.Send(deleteCommand);
    Console.WriteLine(deleted ? "Student deleted successfully" : "Deletion failed");


    // Add Students
    await mediator.Send(new CreateStudentCommand
    {
        StudentDto = new StudentDto
        {
            Name = "Medha Sri",
            DateOfBirth = new DateTime(2022, 06, 06),
            ClassRoomId = classroomId
        },
        User = "System"
    });

    await mediator.Send(new CreateStudentCommand
    {
        StudentDto = new StudentDto
        {
            Name = "Nithisksha",
            DateOfBirth = new DateTime(2024, 03, 28),
            ClassRoomId = classroomId
        },
        User = "System"
    });

    // Add Teacher
    await mediator.Send(new CreateTeacherCommand
    {
        TeacherDto = new TeacherDto
        {
            Name = "Ramana Chari",
            Subjects = ["JAVA", "C#", ".NET", "MSSQL"],
            ClassRoomId = classroomId
        },
        User = "System"
    });


    var classRoomDetails = await mediator.Send(new GetClassRoomDetailsQuery());
    PrintClassRoomDetails(classRoomDetails);
    Console.ReadKey();
});

static void PrintClassRoomDetails(IEnumerable<ClassRoomDto> classRoomDetails)
{
    foreach (var classRoom in classRoomDetails)
    {
        Console.WriteLine("-------------------------------------------------");
        Console.WriteLine($"Classroom ID: {classRoom.Id}");
        Console.WriteLine($"Classroom Name: {classRoom.Name}");
        Console.WriteLine($"Location: {classRoom.Location}");
        Console.WriteLine();

        Console.WriteLine("Teacher:");
        if (classRoom.Teacher != null)
        {
            Console.WriteLine($"\tID: {classRoom.Teacher.Id}");
            Console.WriteLine($"\tName: {classRoom.Teacher.Name}");
            Console.WriteLine($"\tSubject: {classRoom.Teacher.Subject}");
        }
        else
        {
            Console.WriteLine("\tNo teacher assigned.");
        }
        Console.WriteLine();

        Console.WriteLine("Students:");
        if (classRoom.Students != null && classRoom.Students.Any())
        {
            foreach (var student in classRoom.Students)
            {
                Console.WriteLine($"\tID: {student.Id}");
                Console.WriteLine($"\tName: {student.Name}");
                Console.WriteLine($"\tDate of Birth: {student.DateOfBirth:yyyy-MM-dd}");
                Console.WriteLine($"\tAge: {student.Age}");
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("\tNo students enrolled.");
        }
        Console.WriteLine("-------------------------------------------------");
    }
}
