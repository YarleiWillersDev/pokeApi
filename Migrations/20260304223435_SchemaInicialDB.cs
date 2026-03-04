using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokeAPI.Migrations
{
    /// <inheritdoc />
    public partial class SchemaInicialDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PokemonColorGroup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Color = table.Column<string>(type: "TEXT", maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonColorGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pokemon",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Especie = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    ColorGroupId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pokemon", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pokemon_PokemonColorGroup_ColorGroupId",
                        column: x => x.ColorGroupId,
                        principalTable: "PokemonColorGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pokemon_ColorGroupId",
                table: "Pokemon",
                column: "ColorGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_PokemonColorGroup_Color",
                table: "PokemonColorGroup",
                column: "Color",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pokemon");

            migrationBuilder.DropTable(
                name: "PokemonColorGroup");
        }
    }
}
