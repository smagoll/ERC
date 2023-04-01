using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERC.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Rate = table.Column<float>(type: "REAL", nullable: false),
                    Standard = table.Column<float>(type: "REAL", nullable: false),
                    Unit = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LastCalculations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CalculationColdWater = table.Column<float>(type: "REAL", nullable: false),
                    CalculationHotWaterCoolant = table.Column<float>(type: "REAL", nullable: false),
                    CalculationHotWaterThermalEnergy = table.Column<float>(type: "REAL", nullable: false),
                    CalculationElectricityDay = table.Column<float>(type: "REAL", nullable: false),
                    CalculationElectricityNight = table.Column<float>(type: "REAL", nullable: false),
                    ClientId = table.Column<int>(type: "INTEGER", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "LastIndicators",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ColdWaterIndicator = table.Column<float>(type: "REAL", nullable: false),
                    HotWaterIndicator = table.Column<float>(type: "REAL", nullable: false),
                    ElectricityDayIndicator = table.Column<float>(type: "REAL", nullable: false),
                    ElectricityNightIndicator = table.Column<float>(type: "REAL", nullable: false),
                    ClientId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LastIndicators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LastIndicators_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LastCalculations_ClientId",
                table: "LastCalculations",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_LastIndicators_ClientId",
                table: "LastIndicators",
                column: "ClientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LastCalculations");

            migrationBuilder.DropTable(
                name: "LastIndicators");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
