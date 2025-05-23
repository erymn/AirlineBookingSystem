using System.Data;
using System.Reflection;
using AirlineBookingSystem.Notification.Application.Handlers;
using AirlineBookingSystem.Notification.Application.Interfaces;
using AirlineBookingSystem.Notification.Application.Services;
using AirlineBookingSystem.Notification.Core.Repositories;
using AirlineBookingSystem.Notification.Infrastructure.Repositories;
using MediatR;
using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register MediatR
var assembly = new Assembly[]
{
    Assembly.GetExecutingAssembly(),
    typeof(SendNotificationHandler).Assembly,
};
builder.Services.AddMediatR(assembly);

builder.Services.AddScoped<IDbConnection>(sp =>
    new SqlConnection(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddScoped<INotificationRepository, NotificationRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();
