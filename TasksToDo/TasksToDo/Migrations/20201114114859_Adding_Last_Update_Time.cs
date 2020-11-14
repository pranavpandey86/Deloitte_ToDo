using Microsoft.EntityFrameworkCore.Migrations;

namespace TasksToDo.Migrations
{
    public partial class Adding_Last_Update_Time : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LastUpdatedDateTime",
                table: "Tasks",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastUpdatedDateTime",
                table: "Tasks");
        }
    }
}
