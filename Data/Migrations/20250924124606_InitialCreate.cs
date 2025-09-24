using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    ClassId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClassName = table.Column<string>(type: "TEXT", nullable: false),
                    ClassYear = table.Column<int>(type: "INTEGER", nullable: false),
                    ClassGrade = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.ClassId);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StudentFirstName = table.Column<string>(type: "TEXT", nullable: false),
                    StudentLastName = table.Column<string>(type: "TEXT", nullable: false),
                    StudentCemisId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                });

            migrationBuilder.CreateTable(
                name: "Templates",
                columns: table => new
                {
                    TemplateId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TemplateYear = table.Column<int>(type: "INTEGER", nullable: false),
                    TemplateGrade = table.Column<int>(type: "INTEGER", nullable: false),
                    TemplateSubject = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Templates", x => x.TemplateId);
                });

            migrationBuilder.CreateTable(
                name: "Enrollments",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "INTEGER", nullable: false),
                    ClassId = table.Column<int>(type: "INTEGER", nullable: false),
                    EnrollmentId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollments", x => new { x.StudentId, x.ClassId });
                    table.ForeignKey(
                        name: "FK_Enrollments_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollments_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Assessments",
                columns: table => new
                {
                    AssessmentId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AssessmentName = table.Column<string>(type: "TEXT", nullable: false),
                    AssessmentMaxScore = table.Column<int>(type: "INTEGER", nullable: false),
                    AssessmentWeight = table.Column<double>(type: "REAL", nullable: false),
                    TemplateId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assessments", x => x.AssessmentId);
                    table.ForeignKey(
                        name: "FK_Assessments_Templates_TemplateId",
                        column: x => x.TemplateId,
                        principalTable: "Templates",
                        principalColumn: "TemplateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Marksheets",
                columns: table => new
                {
                    MarksheetId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MarksheetIssuedBy = table.Column<string>(type: "TEXT", nullable: false),
                    ClassId = table.Column<int>(type: "INTEGER", nullable: false),
                    TemplateId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marksheets", x => x.MarksheetId);
                    table.ForeignKey(
                        name: "FK_Marksheets_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "ClassId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Marksheets_Templates_TemplateId",
                        column: x => x.TemplateId,
                        principalTable: "Templates",
                        principalColumn: "TemplateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentMarks",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "INTEGER", nullable: false),
                    AssessmentId = table.Column<int>(type: "INTEGER", nullable: false),
                    MarksheetId = table.Column<int>(type: "INTEGER", nullable: false),
                    StudentMarkId = table.Column<int>(type: "INTEGER", nullable: false),
                    StudentMarkScore = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentMarks", x => new { x.MarksheetId, x.StudentId, x.AssessmentId });
                    table.ForeignKey(
                        name: "FK_StudentMarks_Assessments_AssessmentId",
                        column: x => x.AssessmentId,
                        principalTable: "Assessments",
                        principalColumn: "AssessmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentMarks_Marksheets_MarksheetId",
                        column: x => x.MarksheetId,
                        principalTable: "Marksheets",
                        principalColumn: "MarksheetId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentMarks_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assessments_TemplateId",
                table: "Assessments",
                column: "TemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_ClassId",
                table: "Enrollments",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Marksheets_ClassId",
                table: "Marksheets",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Marksheets_TemplateId",
                table: "Marksheets",
                column: "TemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentMarks_AssessmentId",
                table: "StudentMarks",
                column: "AssessmentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentMarks_StudentId",
                table: "StudentMarks",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enrollments");

            migrationBuilder.DropTable(
                name: "StudentMarks");

            migrationBuilder.DropTable(
                name: "Assessments");

            migrationBuilder.DropTable(
                name: "Marksheets");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Templates");
        }
    }
}
