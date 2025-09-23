using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Data;

public class GradiumDbContext : DbContext
{
    public GradiumDbContext(DbContextOptions<GradiumDbContext> options)
        : base(options) { }

    public DbSet<Student> Students => Set<Student>();
}
