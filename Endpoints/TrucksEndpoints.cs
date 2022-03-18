using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Minimal.Data;
using Minimal.Extensions;
using Minimal.Models;

namespace Minimal.Endpoints;

public static class TrucksEndpoints
{
    public static void MapTruckEndpoints(this WebApplication app)
    {
        app.MapGet("/trucks", async (ContextDb db) => await db.Trucks.ToListAsync());

        app.MapGet("/trucks/{id}", async (Guid id, ContextDb db)
            => await db.Trucks.FindAsync(id) is Truck truck ? Results.Ok(truck) : Results.NotFound());

        app.MapPost("/trucks", async (Truck truck, ContextDb db, IValidator<Truck> validator) =>
        {
            var validationResult = validator.Validate(truck);
            if (!validationResult.IsValid)
                return Results.ValidationProblem(validationResult.ToDictionary());

            db.Trucks.Add(truck);
            await db.SaveChangesAsync();
            return Results.Created($"/trucks/{truck.Id}", truck);
        })
         .ProducesValidationProblem()
         .Produces<Truck>(StatusCodes.Status201Created)
         .Produces(StatusCodes.Status400BadRequest);

        app.MapPut("/trucks/{id}", async (Guid id, Truck inputTruck, ContextDb db, IValidator<Truck> validator) =>
        {
            var truck = await db.Trucks.FindAsync(id);

            if (truck is null) return Results.NotFound();

            var validationResult = validator.Validate(inputTruck);
            if (!validationResult.IsValid)
                return Results.ValidationProblem(validationResult.ToDictionary());

            truck.Model = inputTruck.Model;
            truck.ModelDate = inputTruck.ModelDate;
            truck.ManufacturingDate = inputTruck.ManufacturingDate;

            await db.SaveChangesAsync();

            return Results.NoContent();
        });

        app.MapDelete("/trucks/{id}", async (Guid id, ContextDb db) =>
        {
            if (await db.Trucks.FindAsync(id) is Truck truck)
            {
                db.Trucks.Remove(truck);
                await db.SaveChangesAsync();
                return Results.NoContent();
            }

            return Results.NotFound();
        });
    }


}
