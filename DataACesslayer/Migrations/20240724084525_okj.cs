using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataACesslayer.Migrations
{
    /// <inheritdoc />
    public partial class okj : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentDepartmentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departments_Departments_ParentDepartmentId",
                        column: x => x.ParentDepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Logo", "Name", "ParentDepartmentId" },
                values: new object[,]
                {
                    { 1, "hr-logo.png", "HR", null },
                    { 2, "it-logo.png", "IT", null },
                    { 3, "finance-logo.png", "Finance", null },
                    { 4, "recruitment-logo.png", "Recruitment", 1 },
                    { 5, "employee-relations-logo.png", "Employee Relations", 1 },
                    { 6, "software-development-logo.png", "Software Development", 2 },
                    { 7, "it-support-logo.png", "IT Support", 2 },
                    { 8, "accounting-logo.png", "Accounting", 3 },
                    { 9, "budgeting-logo.png", "Budgeting", 3 },
                    { 10, "campus-recruitment-logo.png", "Campus Recruitment", 4 },
                    { 11, "corporate-relations-logo.png", "Corporate Relations", 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departments_ParentDepartmentId",
                table: "Departments",
                column: "ParentDepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
