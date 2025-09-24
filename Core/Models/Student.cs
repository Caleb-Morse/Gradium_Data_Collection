namespace Core.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentFirstName { get; set; } = string.Empty;
        public string StudentLastName { get; set; } = string.Empty;
        public string StudentCemisId { get; set; } = string.Empty;

        // Navigation properties
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
        public ICollection<StudentMark> StudentMarks { get; set; } = new List<StudentMark>();
    }
}