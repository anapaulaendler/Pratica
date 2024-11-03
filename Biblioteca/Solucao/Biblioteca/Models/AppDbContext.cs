using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Autor> TabelaAutores { get; set; }
    public DbSet<Emprestimo> TabelaEmprestimos { get; set; }
    public DbSet<Livro> TabelaLivros { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=BancoDeDados.db");
    }

}