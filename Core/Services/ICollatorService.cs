using System;

namespace Core.Services;

public interface ICollatorService
{
    void CollateMarksheets(int year, string subject);
}
