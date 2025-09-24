using System;
using Data;

namespace Core.Services;

public class CollatorService : ICollatorService
{
    private readonly GradiumDbContext _context;

    public CollatorService(GradiumDbContext context)
    {
        _context = context;
    }

    public void CollateMarksheets(int year, string subject)
    {
        Console.WriteLine($"Collated marksheets for {subject}, year {year}!");
    }
}
