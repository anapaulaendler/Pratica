public class Emprestimo
{
    public string EmprestimoId { get; set; } = Guid.NewGuid().ToString();
    public required string LivroId { get; set; }
    public required string Leitor { get; set; }
    public required string DataDevolucao { get; set; }
}