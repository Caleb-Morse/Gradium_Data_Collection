using System;
using Data;

namespace Core.Services;

public class MarksheetService : IMarksheetService
{
    private readonly GradiumDbContext _context;

    public MarksheetService(GradiumDbContext context)
    {
        _context = context;
    }

    public void CreateMarksheet(int classId, int templateId)
    {
        Console.WriteLine($"Marksheet for class {classId} with template {templateId} was created!");
    }

    public void UpdateStudentMark(int marksheetId, int studentId, int assessmentId, int score)
    {
        Console.WriteLine($"Student {studentId} scored {score} on assessment {assessmentId} (Marksheet {marksheetId})!");
    }
}
