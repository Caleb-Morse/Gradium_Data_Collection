using System;

namespace Core.Services;

public interface ITemplateService
{
    void CreateTemplate(string name, int year, string subject, string term);
    void ExportTemplate(int templateId, string filePath);
    void ImportTemplate(string filePath);
}
