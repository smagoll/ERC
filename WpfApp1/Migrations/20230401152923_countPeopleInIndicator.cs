using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERC.Migrations
{
    /// <inheritdoc />
    public partial class countPeopleInIndicator : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "CountPeople",
                table: "Indicators",
                type: "REAL",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountPeople",
                table: "Indicators");
        }
    }
}
