using System;

namespace Core.Models;

public class Enrollment
{
    public int EnrollmentId { get; set; }

    // Foreign Keys
    public int StudentId { get; set; }
    public int ClassId { get; set; }

    // Navigation Properties
    public Student? Student { get; set; }
    public Class? Class { get; set; }
}
