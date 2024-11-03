public class Autor
{
    public string AutorId { get; set; } = Guid.NewGuid().ToString();
    public required string Nome { get; set; }
    public required string Nacionalidade { get; set; }
}