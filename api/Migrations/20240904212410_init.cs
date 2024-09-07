using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "zamestnanci",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titul = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    meno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    priezvisko = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    telefon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_zamestnanci", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "firmy",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nazov = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    kod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    riaditelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_firmy", x => x.id);
                    table.ForeignKey(
                        name: "FK_firmy_zamestnanci_riaditelId",
                        column: x => x.riaditelId,
                        principalTable: "zamestnanci",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "divizie",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nazov = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    kod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    veduciDivizieId = table.Column<int>(type: "int", nullable: false),
                    Firmaid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_divizie", x => x.id);
                    table.ForeignKey(
                        name: "FK_divizie_firmy_Firmaid",
                        column: x => x.Firmaid,
                        principalTable: "firmy",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_divizie_zamestnanci_veduciDivizieId",
                        column: x => x.veduciDivizieId,
                        principalTable: "zamestnanci",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "projekty",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nazov = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    kod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    veduciProjektuId = table.Column<int>(type: "int", nullable: false),
                    Diviziaid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projekty", x => x.id);
                    table.ForeignKey(
                        name: "FK_projekty_divizie_Diviziaid",
                        column: x => x.Diviziaid,
                        principalTable: "divizie",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_projekty_zamestnanci_veduciProjektuId",
                        column: x => x.veduciProjektuId,
                        principalTable: "zamestnanci",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "oddelenia",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nazov = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    kod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    veduciOddeleniaId = table.Column<int>(type: "int", nullable: false),
                    Projektid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_oddelenia", x => x.id);
                    table.ForeignKey(
                        name: "FK_oddelenia_projekty_Projektid",
                        column: x => x.Projektid,
                        principalTable: "projekty",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_oddelenia_zamestnanci_veduciOddeleniaId",
                        column: x => x.veduciOddeleniaId,
                        principalTable: "zamestnanci",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_divizie_Firmaid",
                table: "divizie",
                column: "Firmaid");

            migrationBuilder.CreateIndex(
                name: "IX_divizie_veduciDivizieId",
                table: "divizie",
                column: "veduciDivizieId");

            migrationBuilder.CreateIndex(
                name: "IX_firmy_riaditelId",
                table: "firmy",
                column: "riaditelId");

            migrationBuilder.CreateIndex(
                name: "IX_oddelenia_Projektid",
                table: "oddelenia",
                column: "Projektid");

            migrationBuilder.CreateIndex(
                name: "IX_oddelenia_veduciOddeleniaId",
                table: "oddelenia",
                column: "veduciOddeleniaId");

            migrationBuilder.CreateIndex(
                name: "IX_projekty_Diviziaid",
                table: "projekty",
                column: "Diviziaid");

            migrationBuilder.CreateIndex(
                name: "IX_projekty_veduciProjektuId",
                table: "projekty",
                column: "veduciProjektuId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "oddelenia");

            migrationBuilder.DropTable(
                name: "projekty");

            migrationBuilder.DropTable(
                name: "divizie");

            migrationBuilder.DropTable(
                name: "firmy");

            migrationBuilder.DropTable(
                name: "zamestnanci");
        }
    }
}
