using System;
using Data;

namespace Core.Services;

public class ClassService : IClassService
{
    private readonly GradiumDbContext _context;

    public ClassService(GradiumDbContext context)
    {
        _context = context;
    }

    public void CreateClass(string name)
    {
        Console.WriteLine($"Class '{name}' was created!");
    }

    public void EnrollStudent(int classId, int studentId)
    {
        Console.WriteLine($"Student {studentId} enrolled into class {classId}!");
    }
}

