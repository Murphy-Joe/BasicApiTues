using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BasicApi.Migrations
{
    public partial class AddedStateToAgent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Agents",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                table: "Agents");
        }
    }
}
