using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Data;

public class GradiumDbContextFactory : IDesignTimeDbContextFactory<GradiumDbContext>
{
    public GradiumDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<GradiumDbContext>();
        optionsBuilder.UseSqlite("Data Source=gradium.db");

        return new GradiumDbContext(optionsBuilder.Options);
    }
}
