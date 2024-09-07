using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class updateDivizia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_divizie_firmy_Firmaid",
                table: "divizie");

            migrationBuilder.DropForeignKey(
                name: "FK_oddelenia_projekty_Projektid",
                table: "oddelenia");

            migrationBuilder.DropForeignKey(
                name: "FK_projekty_divizie_Diviziaid",
                table: "projekty");

            migrationBuilder.DropIndex(
                name: "IX_projekty_Diviziaid",
                table: "projekty");

            migrationBuilder.DropIndex(
                name: "IX_oddelenia_Projektid",
                table: "oddelenia");

            migrationBuilder.DropIndex(
                name: "IX_divizie_Firmaid",
                table: "divizie");

            migrationBuilder.RenameColumn(
                name: "Diviziaid",
                table: "projekty",
                newName: "diviziaId");

            migrationBuilder.RenameColumn(
                name: "Projektid",
                table: "oddelenia",
                newName: "projektId");

            migrationBuilder.RenameColumn(
                name: "Firmaid",
                table: "divizie",
                newName: "firmaId");

            migrationBuilder.AlterColumn<int>(
                name: "firmaId",
                table: "divizie",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "diviziaId",
                table: "projekty",
                newName: "Diviziaid");

            migrationBuilder.RenameColumn(
                name: "projektId",
                table: "oddelenia",
                newName: "Projektid");

            migrationBuilder.RenameColumn(
                name: "firmaId",
                table: "divizie",
                newName: "Firmaid");

            migrationBuilder.AlterColumn<int>(
                name: "Firmaid",
                table: "divizie",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_projekty_Diviziaid",
                table: "projekty",
                column: "Diviziaid");

            migrationBuilder.CreateIndex(
                name: "IX_oddelenia_Projektid",
                table: "oddelenia",
                column: "Projektid");

            migrationBuilder.CreateIndex(
                name: "IX_divizie_Firmaid",
                table: "divizie",
                column: "Firmaid");

            migrationBuilder.AddForeignKey(
                name: "FK_divizie_firmy_Firmaid",
                table: "divizie",
                column: "Firmaid",
                principalTable: "firmy",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_oddelenia_projekty_Projektid",
                table: "oddelenia",
                column: "Projektid",
                principalTable: "projekty",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_projekty_divizie_Diviziaid",
                table: "projekty",
                column: "Diviziaid",
                principalTable: "divizie",
                principalColumn: "id");
        }
    }
}
