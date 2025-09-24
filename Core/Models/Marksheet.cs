using System;

namespace Core.Models;

public class Marksheet
{
    public int MarksheetId { get; set; }
    public string MarksheetIssuedBy { get; set; } = string.Empty;

    // Foreign Keys
    public int ClassId { get; set; }
    public int TemplateId { get; set; }

    // Navigation Properties
    public Class? Class { get; set; }
    public Template? Template { get; set; }
    public ICollection<StudentMark> StudentMarks { get; set; } = new List<StudentMark>();
}
