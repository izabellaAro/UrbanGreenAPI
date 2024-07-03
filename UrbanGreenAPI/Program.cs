using Microsoft.EntityFrameworkCore;
using UrbanGreen.DataAcess.Persistence;
using UrbanGreen.DataAcess.Repositories;
using UrbanGreen.DataAcess.Repositories.Impl;
using UrbanGreenAPI.Application.Services;
using UrbanGreenAPI.Application.Services.Impl;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("ConnectionDB");
builder.Services.AddDbContext<DataContext>(opts => opts.UseSqlServer(connectionString));

builder.Services.AddScoped<IInsumoRepository, InsumoRepository>();

builder.Services.AddScoped<IInsumoService, InsumoService>();

builder.Services.AddControllers();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());
});

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

app.UseCors("CorsPolicy");

app.Run();
