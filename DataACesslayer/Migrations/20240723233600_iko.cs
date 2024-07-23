using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataACesslayer.Migrations
{
    /// <inheritdoc />
    public partial class iko : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentDepartmentID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentID);
                    table.ForeignKey(
                        name: "FK_Departments_Departments_ParentDepartmentID",
                        column: x => x.ParentDepartmentID,
                        principalTable: "Departments",
                        principalColumn: "DepartmentID");
                });

            migrationBuilder.CreateTable(
                name: "SubDepartments",
                columns: table => new
                {
                    SubDepartmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentID = table.Column<int>(type: "int", nullable: true),
                    DepartmentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDepartments", x => x.SubDepartmentID);
                    table.ForeignKey(
                        name: "FK_SubDepartments_Departments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "DepartmentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubDepartments_SubDepartments_ParentID",
                        column: x => x.ParentID,
                        principalTable: "SubDepartments",
                        principalColumn: "SubDepartmentID");
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentID", "Logo", "Name", "ParentDepartmentID" },
                values: new object[,]
                {
                    { 1, "hr-logo.png", "HR", null },
                    { 2, "it-logo.png", "IT", null },
                    { 3, "finance-logo.png", "Finance", null }
                });

            migrationBuilder.InsertData(
                table: "SubDepartments",
                columns: new[] { "SubDepartmentID", "DepartmentID", "Logo", "Name", "ParentID" },
                values: new object[,]
                {
                    { 1, 1, "recruitment-logo.png", "Recruitment", null },
                    { 2, 1, "employee-relations-logo.png", "Employee Relations", null },
                    { 3, 2, "software-development-logo.png", "Software Development", null },
                    { 4, 2, "it-support-logo.png", "IT Support", null },
                    { 5, 3, "accounting-logo.png", "Accounting", null },
                    { 6, 3, "budgeting-logo.png", "Budgeting", null },
                    { 7, 1, "campus-recruitment-logo.png", "Campus Recruitment", 1 },
                    { 8, 1, "corporate-relations-logo.png", "Corporate Relations", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departments_ParentDepartmentID",
                table: "Departments",
                column: "ParentDepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_SubDepartments_DepartmentID",
                table: "SubDepartments",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_SubDepartments_ParentID",
                table: "SubDepartments",
                column: "ParentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubDepartments");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
