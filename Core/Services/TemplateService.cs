using System;
using Data;

namespace Core.Services;

public class TemplateService : ITemplateService
{
    private readonly GradiumDbContext _context;

    public TemplateService(GradiumDbContext context)
    {
        _context = context;
    }

    public void CreateTemplate(string name, int year, string subject, string term)
    {
        Console.WriteLine($"Template '{name}' for {subject} ({term} {year}) was created!");
        // TODO: Add DB logic here
    }

    public void ExportTemplate(int templateId, string filePath)
    {
        Console.WriteLine($"Template {templateId} exported to {filePath}!");
    }

    public void ImportTemplate(string filePath)
    {
        Console.WriteLine($"Template imported from {filePath}!");
    }
}
