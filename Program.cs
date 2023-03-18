using Microsoft.AspNetCore.Mvc;
using repaso1;
using repaso1.models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSqlServer<TareasContext>(builder.Configuration.GetConnectionString("cnTarea"));

var app = builder.Build();



app.MapGet("/", () => "Hello World!");
app.MapGet("/dbconexion", async([FromServices] TareasContext dbContext)=>
{
    dbContext.Database.EnsureCreated();
    return Results.Ok("Base de datos Creada");
});

app.MapGet("/api/tareas", async ([FromServices] TareasContext dbContext)=>
{
    return Results.Ok(dbContext.Tareas);
});

app.MapPost("/api/tareas", async([FromServices] TareasContext dbContext, [FromBody] Tarea tarea)=>{

    tarea.TareaId=Guid.NewGuid();
    tarea.FechaCreacion=DateTime.Now;
    await dbContext.AddAsync(tarea);
    await dbContext.SaveChangesAsync();
    return Results.Ok();

});


app.MapPut("/api/tareas/{id}", async([FromServices] TareasContext dbContext, [FromBody] Tarea tarea,[FromRoute] Guid id)=>{
    var tareaActual=dbContext.Tareas.Find(id);
    if (tareaActual!=null)
    {
        tareaActual.CategoriaId=tarea.CategoriaId;
        tareaActual.Titulo=tarea.Titulo;
        tareaActual.Prioridad=tarea.Prioridad;
        tareaActual.Descripcion=tarea.Descripcion;
        await dbContext.SaveChangesAsync();
        return Results.Ok();
    }
    else
    {
        return Results.NotFound();
    }
});

app.MapDelete("/api/tareas/{id}", async([FromServices] TareasContext dbContext,[FromRoute] Guid id)=>{
    var tareaActual=dbContext.Tareas.Find(id);
    if (tareaActual!=null)
    {
        dbContext.Remove(tareaActual);
        await dbContext.SaveChangesAsync();
        return Results.Ok();
    }
    return Results.NotFound();
});

app.Run();
