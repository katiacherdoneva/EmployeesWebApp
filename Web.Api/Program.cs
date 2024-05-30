using CsvHelper.Configuration;
using System.Globalization;
using Web.Api.Interfaces;
using Web.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddScoped<IEmployeeService, EmployeesService>();

builder.Services.AddControllers();
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

var config = new CsvConfiguration(CultureInfo.InvariantCulture)
{
    NewLine = Environment.NewLine,
};

app.MapControllers();

app.Run();


