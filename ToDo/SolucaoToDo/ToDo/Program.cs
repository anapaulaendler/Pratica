var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Activities API");

app.MapPost("/api/create", ([FromBody] Activity activity, [FromServices] AppDataContext ctx) =>
{
    ctx.ActivityTable.Add(activity);
    ctx.SaveChanges();
    return Results.Ok();
});

app.MapPost("/api/create/list", ([FromBody] List<Activity> activities, [FromServices] AppDataContext ctx) =>
{
    ctx.ActivityTable.AddRange(activities);
    ctx.SaveChanges();
    return Results.Ok();
});

app.MapGet("/api/read", ([FromServices] AppDataContext ctx) =>
{
    if (ctx.ActivityTable.Any())
    {
        List<Activity> activities = ctx.ActivityTable().ToList();
        return Results.Ok(activities);
    }

    return Results.NotFound();
});

app.Run();
