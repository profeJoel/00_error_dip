using Microsoft.EntityFrameworkCore;
using ejemploColegio.Data;
using ejemploColegio.Models;
namespace ejemploColegio.Controllers;

public static class EstudianteEndpoints
{
    public static void MapEstudianteEndpoints (this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/Estudiante", async (ApplicationDbContext db) =>
        {
            return await db.Estudiante.ToListAsync();
        })
        .WithName("GetAllEstudiantes")
        .Produces<List<Estudiante>>(StatusCodes.Status200OK);

        routes.MapGet("/api/Estudiante/{id}", async (int Id, ApplicationDbContext db) =>
        {
            return await db.Estudiante.FindAsync(Id)
                is Estudiante model
                    ? Results.Ok(model)
                    : Results.NotFound();
        })
        .WithName("GetEstudianteById")
        .Produces<Estudiante>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        routes.MapPut("/api/Estudiante/{id}", async (int Id, Estudiante estudiante, ApplicationDbContext db) =>
        {
            var foundModel = await db.Estudiante.FindAsync(Id);

            if (foundModel is null)
            {
                return Results.NotFound();
            }
            //update model properties here

            await db.SaveChangesAsync();

            return Results.NoContent();
        })
        .WithName("UpdateEstudiante")
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status204NoContent);

        routes.MapPost("/api/Estudiante/", async (Estudiante estudiante, ApplicationDbContext db) =>
        {
            db.Estudiante.Add(estudiante);
            await db.SaveChangesAsync();
            return Results.Created($"/Estudiantes/{estudiante.Id}", estudiante);
        })
        .WithName("CreateEstudiante")
        .Produces<Estudiante>(StatusCodes.Status201Created);

        routes.MapDelete("/api/Estudiante/{id}", async (int Id, ApplicationDbContext db) =>
        {
            if (await db.Estudiante.FindAsync(Id) is Estudiante estudiante)
            {
                db.Estudiante.Remove(estudiante);
                await db.SaveChangesAsync();
                return Results.Ok(estudiante);
            }

            return Results.NotFound();
        })
        .WithName("DeleteEstudiante")
        .Produces<Estudiante>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);
    }
}
