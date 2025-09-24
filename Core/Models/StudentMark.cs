using System;

namespace Core.Models;

public class StudentMark
{
    public int StudentMarkId { get; set; }
    public double StudentMarkScore { get; set; }

    // Foreign Keys
    public int StudentId { get; set; }
    public int AssessmentId { get; set; }
    public int MarksheetId { get; set; }


    // Navigation Properties
    public Student? Student { get; set; }
    public Assessment? Assessment { get; set; }
    public Marksheet? Marksheet { get; set; }
}
