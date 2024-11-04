using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biblioteca.Migrations
{
    /// <inheritdoc />
    public partial class AtualizandoEmprestimoNovamente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TabelaEmprestimos_TabelaLivros_LivroId",
                table: "TabelaEmprestimos");

            migrationBuilder.DropIndex(
                name: "IX_TabelaEmprestimos_LivroId",
                table: "TabelaEmprestimos");

            migrationBuilder.AlterColumn<string>(
                name: "LivroId",
                table: "TabelaEmprestimos",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LivroId",
                table: "TabelaEmprestimos",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.CreateIndex(
                name: "IX_TabelaEmprestimos_LivroId",
                table: "TabelaEmprestimos",
                column: "LivroId");

            migrationBuilder.AddForeignKey(
                name: "FK_TabelaEmprestimos_TabelaLivros_LivroId",
                table: "TabelaEmprestimos",
                column: "LivroId",
                principalTable: "TabelaLivros",
                principalColumn: "LivroId");
        }
    }
}
