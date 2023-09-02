using Application.Interfaces;
using Application.Service;
using Application.Service.Interfaces;
using Infrastructure.DbContexts;
using Infrastructure.UoW;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//temp
builder.Services.AddCors(); 
builder.Services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);


// Add services to the container.

builder.Services.AddControllers();

// Database
builder.Services.AddDbContext<PortfolioDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"), o => o.UseNodaTime()));
builder.Services.AddHealthChecks().AddNpgSql(builder.Configuration.GetConnectionString("DefaultConnection"), name: "PortfolioDB");

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IEducationService, EducationService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//temp
app.UseCors(options => options.WithOrigins("http://127.0.0.1:5500").AllowAnyMethod());

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
