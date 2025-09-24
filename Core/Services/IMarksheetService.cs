using System;

namespace Core.Services;

public interface IMarksheetService
{
    void CreateMarksheet(int classId, int templateId);
    void UpdateStudentMark(int marksheetId, int studentId, int assessmentId, int score);
}
