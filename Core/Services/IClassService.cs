using System;

namespace Core.Services;

public interface IClassService
{
    void CreateClass(string name);
    void EnrollStudent(int classId, int studentId);
}
