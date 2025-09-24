using System;

namespace Core.Models;

public class Class
{
    public int ClassId { get; set; }
    public string ClassName { get; set; } = string.Empty;
    public int ClassYear { get; set; }
    public int ClassGrade { get; set; }

    // Navigation properties
    public List<Enrollment> Enrollments { get; set; } = new();
    public List<Marksheet> Marksheets { get; set; } = new();
    
}
