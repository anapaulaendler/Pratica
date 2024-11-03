using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biblioteca.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TabelaAutores",
                columns: table => new
                {
                    AutorId = table.Column<string>(type: "TEXT", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Nacionalidade = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TabelaAutores", x => x.AutorId);
                });

            migrationBuilder.CreateTable(
                name: "TabelaEmprestimos",
                columns: table => new
                {
                    EmprestimoId = table.Column<string>(type: "TEXT", nullable: false),
                    LivroId = table.Column<string>(type: "TEXT", nullable: false),
                    Leitor = table.Column<string>(type: "TEXT", nullable: false),
                    DataDevolucao = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TabelaEmprestimos", x => x.EmprestimoId);
                });

            migrationBuilder.CreateTable(
                name: "TabelaLivros",
                columns: table => new
                {
                    LivroId = table.Column<string>(type: "TEXT", nullable: false),
                    Titulo = table.Column<string>(type: "TEXT", nullable: false),
                    Genero = table.Column<string>(type: "TEXT", nullable: false),
                    AnoPublicacao = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TabelaLivros", x => x.LivroId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TabelaAutores");

            migrationBuilder.DropTable(
                name: "TabelaEmprestimos");

            migrationBuilder.DropTable(
                name: "TabelaLivros");
        }
    }
}
