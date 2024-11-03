using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biblioteca.Migrations
{
    /// <inheritdoc />
    public partial class AtualizandoLivro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AutorId",
                table: "TabelaLivros",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_TabelaLivros_AutorId",
                table: "TabelaLivros",
                column: "AutorId");

            migrationBuilder.AddForeignKey(
                name: "FK_TabelaLivros_TabelaAutores_AutorId",
                table: "TabelaLivros",
                column: "AutorId",
                principalTable: "TabelaAutores",
                principalColumn: "AutorId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TabelaLivros_TabelaAutores_AutorId",
                table: "TabelaLivros");

            migrationBuilder.DropIndex(
                name: "IX_TabelaLivros_AutorId",
                table: "TabelaLivros");

            migrationBuilder.DropColumn(
                name: "AutorId",
                table: "TabelaLivros");
        }
    }
}
