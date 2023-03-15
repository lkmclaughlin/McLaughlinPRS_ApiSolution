using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace McLaughlinPRS_Api.Migrations
{
    public partial class updatedRequeststable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Requests",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "Requests",
                type: "decimal(11,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "Requests");
        }
    }
}
