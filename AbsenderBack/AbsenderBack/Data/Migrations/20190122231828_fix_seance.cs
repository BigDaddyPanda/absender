using Microsoft.EntityFrameworkCore.Migrations;

namespace AbsenderBack.Data.Migrations
{
    public partial class fix_seance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Day_Of_The_Week",
                table: "Seance",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Day_Of_The_Week",
                table: "Seance");
        }
    }
}
