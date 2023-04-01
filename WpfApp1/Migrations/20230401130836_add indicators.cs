using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERC.Migrations
{
    /// <inheritdoc />
    public partial class addindicators : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Calculations");

            migrationBuilder.DropTable(
                name: "LastIndicators");

            migrationBuilder.CreateTable(
                name: "Indicators",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CWC = table.Column<float>(type: "REAL", nullable: false),
                    HWC = table.Column<float>(type: "REAL", nullable: false),
                    EEDay = table.Column<float>(type: "REAL", nullable: false),
                    EENight = table.Column<float>(type: "REAL", nullable: false),
                    ClientId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Indicators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Indicators_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Indicators_ClientId",
                table: "Indicators",
                column: "ClientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Indicators");

            migrationBuilder.CreateTable(
                name: "Calculations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClientId = table.Column<int>(type: "INTEGER", nullable: false),
                    CalculationCWC = table.Column<float>(type: "REAL", nullable: false),
                    CalculationEE = table.Column<float>(type: "REAL", nullable: false),
                    CalculationEEDay = table.Column<float>(type: "REAL", nullable: false),
                    CalculationEENight = table.Column<float>(type: "REAL", nullable: false),
                    CalculationHWCCoolant = table.Column<float>(type: "REAL", nullable: false),
                    CalculationHWCThermalEnergy = table.Column<float>(type: "REAL", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "LastIndicators",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClientId = table.Column<int>(type: "INTEGER", nullable: false),
                    ColdWaterIndicator = table.Column<float>(type: "REAL", nullable: false),
                    ElectricityDayIndicator = table.Column<float>(type: "REAL", nullable: false),
                    ElectricityNightIndicator = table.Column<float>(type: "REAL", nullable: false),
                    HotWaterIndicator = table.Column<float>(type: "REAL", nullable: false)
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
                name: "IX_Calculations_ClientId",
                table: "Calculations",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_LastIndicators_ClientId",
                table: "LastIndicators",
                column: "ClientId");
        }
    }
}
