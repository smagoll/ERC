using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERC.Migrations
{
    /// <inheritdoc />
    public partial class updatecalculations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "CalculationEE",
                table: "Calculations",
                type: "REAL",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "CalculationEEDay",
                table: "Calculations",
                type: "REAL",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "CalculationEENight",
                table: "Calculations",
                type: "REAL",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "CalculationHWCCoolant",
                table: "Calculations",
                type: "REAL",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "CalculationHWCThermalEnergy",
                table: "Calculations",
                type: "REAL",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CalculationEE",
                table: "Calculations");

            migrationBuilder.DropColumn(
                name: "CalculationEEDay",
                table: "Calculations");

            migrationBuilder.DropColumn(
                name: "CalculationEENight",
                table: "Calculations");

            migrationBuilder.DropColumn(
                name: "CalculationHWCCoolant",
                table: "Calculations");

            migrationBuilder.DropColumn(
                name: "CalculationHWCThermalEnergy",
                table: "Calculations");
        }
    }
}
