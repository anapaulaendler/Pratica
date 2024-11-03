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

app.Run();
