using System;

namespace Core.Models;

public class Assessment
{
    public int AssessmentId { get; set; }
    public string AssessmentName { get; set; } = string.Empty;
    public int AssessmentMaxScore { get; set; }
    public double AssessmentWeight { get; set; }

    // Foreign Keys
    public int TemplateId { get; set; }

    // Navigation Properties
    public Template? Template { get; set; }
    public ICollection<StudentMark> StudentMarks { get; set; } = new List<StudentMark>();
}
