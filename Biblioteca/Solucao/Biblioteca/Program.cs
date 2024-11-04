using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
builder.Services.AddDbContext<AppDbContext>();

app.MapGet("/", () => $"API de biblioteca");

app.MapPost("/api/autor/cadastrar", ([FromBody] Autor autor, [FromServices] AppDbContext ctx) =>
{
    ctx.TabelaAutores.Add(autor);
    ctx.SaveChanges();
    return Results.Created("", autor);
});

app.MapPost("api/autor/cadastrar/lista", ([FromBody] List<Autor> autores, [FromServices] AppDbContext ctx) =>
{
    if (autores is null)
    {
        return Results.NotFound("Lista vazia.");
    }

    ctx.TabelaAutores.AddRange(autores);
    ctx.SaveChanges();
    return Results.Created("", autores);
});

app.MapGet("/api/autor/listar", ([FromServices] AppDbContext ctx) =>
{
    if (ctx.TabelaAutores.Any())
    {
        List<Autor> autores = ctx.TabelaAutores.ToList();
        return Results.Ok(autores);
    }

    return Results.NotFound();
});

app.MapGet("/api/autor/buscar/{id}", ([FromRoute] string id, [FromServices] AppDbContext ctx) =>
{
    Autor? autor = ctx.TabelaAutores.Find(id);

    if (autor is null)
    {
        return Results.NotFound();
    }

    return Results.Ok(autor);
});

app.MapPut("/api/autor/alterar/{id}", ([FromRoute] string id, [FromBody] Autor autorAlterado, [FromServices] AppDbContext ctx) =>
{
    Autor? autor = ctx.TabelaAutores.Find(id);

    if (autor is null)
    {
        return Results.NotFound("Id inválido.");
    }

    autor.Nome = autorAlterado.Nome;
    autor.Nacionalidade = autorAlterado.Nacionalidade;

    return Results.Ok(autor);
});

app.MapDelete("/api/autor/deletar/{id}", ([FromRoute] string id, [FromServices] AppDbContext ctx) =>
{
    Autor? autor = ctx.TabelaAutores.Find(id);
    if (autor is null)
    {
        return Results.NotFound();
    }

    ctx.TabelaAutores.Remove(autor);
    ctx.SaveChanges();
    return Results.Ok();
});

app.MapPost("/api/emprestimo/cadastrar", ([FromBody] Emprestimo emprestimo, [FromServices] AppDbContext ctx) =>
{
    ctx.TabelaEmprestimos.Add(emprestimo);
    ctx.SaveChanges();
    return Results.Created("", emprestimo);
});

app.MapPost("api/emprestimo/cadastrar/lista", ([FromBody] List<Emprestimo> emprestimos, [FromServices] AppDbContext ctx) =>
{
    if (emprestimos is null)
    {
        return Results.NotFound("Lista vazia.");
    }

    ctx.TabelaEmprestimos.AddRange(emprestimos);
    ctx.SaveChanges();
    return Results.Created("", emprestimos);
});

app.MapGet("/api/emprestimo/listar", ([FromServices] AppDbContext ctx) =>
{
    if (ctx.TabelaEmprestimos.Any())
    {
        List<Emprestimo> emprestimos = ctx.TabelaEmprestimos.ToList();
        return Results.Ok(emprestimos);
    }

    return Results.NotFound();
});

app.MapGet("/api/emprestimo/buscar/{id}", ([FromRoute] string id, [FromServices] AppDbContext ctx) =>
{
    Emprestimo? emprestimo = ctx.TabelaEmprestimos.Find(id);

    if (emprestimo is null)
    {
        return Results.NotFound();
    }

    return Results.Ok(emprestimo);
});

app.MapPut("/api/emprestimo/alterar/{id}", ([FromRoute] string id, [FromBody] Emprestimo emprestimoAlterado, [FromServices] AppDbContext ctx) =>
{
    Emprestimo? emprestimo = ctx.TabelaEmprestimos.Find(id);

    if (emprestimo is null)
    {
        return Results.NotFound();
    }

    emprestimo.DataDevolucao = emprestimoAlterado.DataDevolucao;
    emprestimo.Leitor = emprestimoAlterado.Leitor;
    emprestimo.LivroId = emprestimoAlterado.LivroId;

    return Results.Ok(emprestimo);
});

app.MapDelete("/api/emprestimo/deletar/{id}", ([FromRoute] string id, [FromServices] AppDbContext ctx) =>
{
    Emprestimo? emprestimo = ctx.TabelaEmprestimos.Find(id);

    if (emprestimo is null)
    {
        return Results.NotFound();
    }

    ctx.TabelaEmprestimos.Remove(emprestimo);
    ctx.SaveChanges();
    return Results.Ok();
});

app.MapPost("/api/livro/cadastrar", ([FromBody] Livro livro, [FromServices] AppDbContext ctx) =>
{
    ctx.TabelaLivros.Add(livro);
    ctx.SaveChanges();
    return Results.Created("", livro);
});

app.MapPost("api/livro/cadastrar/lista", ([FromBody] List<Livro> livros, [FromServices] AppDbContext ctx) =>
{
    if (livros is null)
    {
        return Results.NotFound("Lista vazia.");
    }

    ctx.TabelaLivros.AddRange(livros);
    ctx.SaveChanges();
    return Results.Created("", livros);
});

app.MapGet("/api/livro/listar", ([FromServices] AppDbContext ctx) =>
{
    if (ctx.TabelaLivros.Any())
    {
        List<Livro> livros = ctx.TabelaLivros.ToList();
        return Results.Ok(livros);
    }

    return Results.NotFound();
});

app.MapGet("/api/livro/buscar/{id}", ([FromRoute] string id, [FromServices] AppDbContext ctx) =>
{
    Livro? livro = ctx.TabelaLivros.Find(id);

    if (livro is null)
    {
        return Results.NotFound();
    }

    return Results.Ok(livro);
});

app.MapPut("/api/livro/alterar/{id}", ([FromRoute] string id, [FromBody] Livro livroAlterado, [FromServices] AppDbContext ctx) =>
{
    Livro? livro = ctx.TabelaLivros.Find(id);

    if (livro is null)
    {
        return Results.NotFound();
    }

    livro.AnoPublicacao = livroAlterado.AnoPublicacao;
    livro.Autor = livroAlterado.Autor;
    livro.Genero = livroAlterado.Genero;
    livro.Titulo = livroAlterado.Titulo;

    return Results.Ok(livro);
});

app.MapDelete("/api/livro/deletar/{id}", ([FromRoute] string id, [FromServices] AppDbContext ctx) =>
{
    Livro? livro = ctx.TabelaLivros.Find(id);

    if (livro is null)
    {
        return Results.NotFound();
    }

    ctx.TabelaLivros.Remove(livro);
    ctx.SaveChanges();
    return Results.Ok();
});

app.Run();
