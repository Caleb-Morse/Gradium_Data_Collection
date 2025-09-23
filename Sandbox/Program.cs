using Core.Models;
using Data;
using Microsoft.EntityFrameworkCore;

// Configure DbContext
var options = new DbContextOptionsBuilder<GradiumDbContext>()
    .UseSqlite("Data Source=gradium.db")
    .Options;

using var context = new GradiumDbContext(options);

// Ensure DB exists
context.Database.EnsureCreated();

// Seed students
var student = new Student { Name = "Alice" };
context.Students.Add(student);
context.SaveChanges();

Console.WriteLine("Student saved: " + student.Name);
