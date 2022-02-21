using BearGoodbyeKolkhozProject.API;
using BearGoodbyeKolkhozProject.API.Extensions;
using BearGoodbyeKolkhozProject.API.Infrastructure;
using BearGoodbyeKolkhozProject.Business.Configuration;
using BearGoodbyeKolkhozProject.Data.ConnectDb;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

const string? _connString = "CONNECTION_STRING";

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetValue<string>(_connString);
builder.Services.AddDbContext<ApplicationContext>(op =>
            op.UseSqlServer(connString));

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.RegisterSwaggerAuth();

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = AuthOptions.Issuer,
            ValidateAudience = true,
            ValidAudience = AuthOptions.Audience,
            ValidateLifetime = true,
            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
            ValidateIssuerSigningKey = true,
        };
    });

// add service and provider connections here
builder.Services.AddAuthorization();
builder.Services.RegisterProjectService();
builder.Services.RegisterProjectRepository();

builder.Services.AddAutoMapper(typeof(APIMapperProfile), typeof(BusinessMapperProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<ErrorHandlerMiddleware>();
app.MapControllers();

app.Run();