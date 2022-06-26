using Microsoft.EntityFrameworkCore;
using BookManagerApi.Models;
using BookManagerApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IBookManagementService, BookManagementService>();
builder.Services.AddControllers();
builder.Services.AddDbContext<BookContext>(option =>
    option.UseInMemoryDatabase("BookDb"));

// Configure Swagger/OpenAPI Documentation
// You can learn more on this link: https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

