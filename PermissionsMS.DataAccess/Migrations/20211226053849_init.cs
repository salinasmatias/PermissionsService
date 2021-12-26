using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PermissionsMS.DataAccess.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PermissionTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeForename = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    EmployeeSurname = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PermissionType = table.Column<int>(type: "int", nullable: false),
                    PermissionDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Permissions_PermissionTypes_PermissionType",
                        column: x => x.PermissionType,
                        principalTable: "PermissionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "PermissionTypes",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "Administrator" },
                    { 2, "Project Manager" },
                    { 3, "Scrum Master" },
                    { 4, "Product Owner" },
                    { 5, "Developer" }
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "EmployeeForename", "EmployeeSurname", "PermissionDate", "PermissionType" },
                values: new object[,]
                {
                    { 5, "Camilo", "Ñañez", new DateTime(2021, 12, 26, 0, 0, 0, 0, DateTimeKind.Local), 1 },
                    { 6, "Waldo", "Hasperué", new DateTime(2021, 12, 26, 0, 0, 0, 0, DateTimeKind.Local), 1 },
                    { 3, "Rodrigo", "Lago", new DateTime(2021, 12, 26, 0, 0, 0, 0, DateTimeKind.Local), 3 },
                    { 4, "Lucas", "Olivera", new DateTime(2021, 12, 26, 0, 0, 0, 0, DateTimeKind.Local), 3 },
                    { 1, "Matías", "Salinas", new DateTime(2021, 12, 26, 0, 0, 0, 0, DateTimeKind.Local), 5 },
                    { 2, "Jose Luís", "Fernández", new DateTime(2021, 12, 26, 0, 0, 0, 0, DateTimeKind.Local), 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_PermissionType",
                table: "Permissions",
                column: "PermissionType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "PermissionTypes");
        }
    }
}
