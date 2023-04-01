using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERC.Migrations
{
    /// <inheritdoc />
    public partial class addcalculations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LastCalculations");

            migrationBuilder.CreateTable(
                name: "Calculations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CalculationCWC = table.Column<float>(type: "REAL", nullable: false),
                    ClientId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calculations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Calculations_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Calculations_ClientId",
                table: "Calculations",
                column: "ClientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Calculations");

            migrationBuilder.CreateTable(
                name: "LastCalculations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClientId = table.Column<int>(type: "INTEGER", nullable: false),
                    CalculationColdWater = table.Column<float>(type: "REAL", nullable: false),
                    CalculationElectricityDay = table.Column<float>(type: "REAL", nullable: false),
                    CalculationElectricityNight = table.Column<float>(type: "REAL", nullable: false),
                    CalculationHotWaterCoolant = table.Column<float>(type: "REAL", nullable: false),
                    CalculationHotWaterThermalEnergy = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LastCalculations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LastCalculations_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LastCalculations_ClientId",
                table: "LastCalculations",
                column: "ClientId");
        }
    }
}
