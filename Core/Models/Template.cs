using System;

namespace Core.Models;

public class Template
{
    public int TemplateId { get; set; }
    public int TemplateYear { get; set; }
    public int TemplateGrade { get; set; }
    public string TemplateSubject { get; set; } = string.Empty;

    // Navigation properties
    public ICollection<Assessment> Assessments { get; set; } = new List<Assessment>();
    public ICollection<Marksheet> Marksheets { get; set; } = new List<Marksheet>();
}
