using BearGoodbyeKolkhozProject.API;
using BearGoodbyeKolkhozProject.API.Configuration.ExceptionResponse;
using BearGoodbyeKolkhozProject.API.Extensions;
using BearGoodbyeKolkhozProject.API.Infrastructure;
using BearGoodbyeKolkhozProject.Business.Configuration;
using BearGoodbyeKolkhozProject.Data.ConnectDb;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

const string? _connString = "BEAR_CONNECTION_STRING";

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetValue<string>(_connString);
builder.Services.AddDbContext<ApplicationContext>(op =>
            op.UseSqlServer(connString));

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddMvc()
    .AddJsonOptions(options =>
    {

        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());

    })

    .ConfigureApiBehaviorOptions(options =>
    {
        options.InvalidModelStateResponseFactory = context =>
        {
            var exc = new ValidationExceptionResponse(context.ModelState);
            return new UnprocessableEntityObjectResult(exc);
        };
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.RegisterSwaggerAuth();

builder.Services.RegisterAuthJwtToken();

// add service and provider connections here
builder.Services.AddAuthorization();
builder.Services.RegisterProjectService();
builder.Services.RegisterProjectRepository();

builder.Services.AddAutoMapper(typeof(APIMapperProfile), typeof(BusinessMapperProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<ErrorHandlerMiddleware>();
app.MapControllers();

app.Run();