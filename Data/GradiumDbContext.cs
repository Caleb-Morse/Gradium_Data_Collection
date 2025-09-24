using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Data;

public class GradiumDbContext : DbContext
{
    public GradiumDbContext(DbContextOptions<GradiumDbContext> options)
        : base(options) { }

    public DbSet<Student> Students => Set<Student>();
    public DbSet<Class> Classes => Set<Class>();
    public DbSet<Enrollment> Enrollments => Set<Enrollment>();
    public DbSet<Template> Templates => Set<Template>();
    public DbSet<Assessment> Assessments => Set<Assessment>();
    public DbSet<Marksheet> Marksheets => Set<Marksheet>();
    public DbSet<StudentMark> StudentMarks => Set<StudentMark>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Student ↔ Class (many-to-many via Enrollment)
        modelBuilder.Entity<Enrollment>()
            .HasKey(e => new { e.StudentId, e.ClassId });

        modelBuilder.Entity<Enrollment>()
            .HasOne(e => e.Student)
            .WithMany(s => s.Enrollments)
            .HasForeignKey(e => e.StudentId);

        modelBuilder.Entity<Enrollment>()
            .HasOne(e => e.Class)
            .WithMany(c => c.Enrollments)
            .HasForeignKey(e => e.ClassId);

        // Template → Assessments (1-to-many)
        modelBuilder.Entity<Assessment>()
            .HasOne(a => a.Template)
            .WithMany(t => t.Assessments)
            .HasForeignKey(a => a.TemplateId)
            .OnDelete(DeleteBehavior.Cascade);

        // Class → Marksheet → Template
        modelBuilder.Entity<Marksheet>()
            .HasOne(m => m.Class)
            .WithMany(c => c.Marksheets)
            .HasForeignKey(m => m.ClassId);

        modelBuilder.Entity<Marksheet>()
            .HasOne(m => m.Template)
            .WithMany(t => t.Marksheets)
            .HasForeignKey(m => m.TemplateId);

        // Marksheet → StudentMarks → (Student + Assessment)
        modelBuilder.Entity<StudentMark>()
            .HasKey(sm => new { sm.MarksheetId, sm.StudentId, sm.AssessmentId });

        modelBuilder.Entity<StudentMark>()
            .HasOne(sm => sm.Marksheet)
            .WithMany(m => m.StudentMarks)
            .HasForeignKey(sm => sm.MarksheetId);

        modelBuilder.Entity<StudentMark>()
            .HasOne(sm => sm.Student)
            .WithMany(s => s.StudentMarks)
            .HasForeignKey(sm => sm.StudentId);

        modelBuilder.Entity<StudentMark>()
            .HasOne(sm => sm.Assessment)
            .WithMany(a => a.StudentMarks)
            .HasForeignKey(sm => sm.AssessmentId);

    }
}
