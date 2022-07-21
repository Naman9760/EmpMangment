using Microsoft.EntityFrameworkCore.Migrations;

namespace EmpMangment.Migrations
{
    public partial class M3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LirstName",
                table: "employeeDatas");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "employeeDatas",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastName",
                table: "employeeDatas");

            migrationBuilder.AddColumn<string>(
                name: "LirstName",
                table: "employeeDatas",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
