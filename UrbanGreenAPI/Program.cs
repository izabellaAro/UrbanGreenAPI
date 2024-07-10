using Microsoft.EntityFrameworkCore;
using UrbanGreen.Application.Interface;
using UrbanGreen.Application.Services.Impl;
using UrbanGreen.Application.Services.Interfaces;
using UrbanGreen.DataAcess.Interface;
using UrbanGreen.DataAcess.Persistence;
using UrbanGreen.DataAcess.Repositories.Impl;
using UrbanGreen.DataAcess.Repositories.Interfaces;
using UrbanGreenAPI.Application.Services.Impl;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("ConnectionDB");
builder.Services.AddDbContext<DataContext>(opts => opts.UseSqlServer(connectionString));

builder.Services.AddScoped<IInsumoRepository, InsumoRepository>();
builder.Services.AddScoped<IPessoaJuridicaRepository, PessoaJuridicaRepository>();
builder.Services.AddScoped<IFornecedorRepository, FornecedorRepository>();
builder.Services.AddScoped<IInspecaoRepository, InspecaoRepository>();
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();

builder.Services.AddScoped<IInsumoService, InsumoService>();
builder.Services.AddScoped<IPessoaJuridicaService, PessoaJuridicaService>();
builder.Services.AddScoped<IFornecedorService, FornecedorService>();
builder.Services.AddScoped<IInspecaoService, InspecaoService>();
builder.Services.AddScoped<IProdutoService, ProdutoService>();


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
