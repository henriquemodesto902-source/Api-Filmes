using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api_Filmes.Migrations
{
    /// <inheritdoc />
    public partial class Classificação : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Genero",
                table: "Filmes",
                newName: "Gênero");

            migrationBuilder.AddColumn<string>(
                name: "Classificação",
                table: "Filmes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Classificação",
                table: "Filmes");

            migrationBuilder.RenameColumn(
                name: "Gênero",
                table: "Filmes",
                newName: "Genero");
        }
    }
}
