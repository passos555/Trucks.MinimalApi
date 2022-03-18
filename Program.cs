using Microsoft.EntityFrameworkCore;
using Minimal.Data;
using Minimal.Endpoints;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthorization();
builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
    {
        builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
    }));
builder.Services.AddDbContext<ContextDb>(opt => opt.UseInMemoryDatabase("Trucks"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddFluentValidation(v => v.RegisterValidatorsFromAssemblyContaining<Program>());

var app = builder.Build();
app.MapTruckEndpoints();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.RoutePrefix = "");
}

app.UseCors("corsapp");
app.UseHttpsRedirection();
app.UseAuthorization();

app.Run();
