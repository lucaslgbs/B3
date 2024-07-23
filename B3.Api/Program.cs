using B3.Application.Service;
using B3.Application.Validation;
using B3.Domain.Dto;
using B3.Domain.Interface.Repository;
using B3.Domain.Interface.Service;
using B3.Infra.Repository;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var devCorsPolicy = "devCorsPolicy";
builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

builder.Services.AddScoped<ICalculatorService, CDBCalculatorService>();
builder.Services.AddScoped<IInvestmentTaxRepository, InvestmentTaxRepository>();
builder.Services.AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<InvestmentCalculatorValidator>());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("corsapp");
app.UseAuthorization();

app.MapControllers();

app.Run();