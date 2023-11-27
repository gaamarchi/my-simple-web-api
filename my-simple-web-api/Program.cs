using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using FilmeAPI.Data;
using System;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using AutoMapper;
using FilmeAPI.Models;
using FilmeAPI.Models.DTOs;
using FilmeAPI.Profile;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<FilmeContext>(opts =>opts.UseLazyLoadingProxies().UseMySql(
    builder.Configuration.GetConnectionString("FilmeConnection"),
    ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("FilmeConnection"))
));


builder.Services.AddControllers().AddNewtonsoftJson();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
