using BearGoodbyeKolkhozProject.API;
using BearGoodbyeKolkhozProject.API.Infrastructure;
using BearGoodbyeKolkhozProject.Business.Configuration;
using BearGoodbyeKolkhozProject.Business.Interface;
using BearGoodbyeKolkhozProject.Business.Services;
using BearGoodbyeKolkhozProject.Data.ConnectDb;
using BearGoodbyeKolkhozProject.Data.Interfaces;
using BearGoodbyeKolkhozProject.Data.Repositories;
using Microsoft.EntityFrameworkCore;

const string _connString = "CONNECTION_STRING";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connString = builder.Configuration.GetValue<string>(_connString);

builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connString));

builder.Services.AddScoped<ITrainingRepository, TrainingRepository>();
builder.Services.AddScoped<ITrainingService, TrainingService>();
builder.Services.AddScoped<ITrainingReviewRepository, TrainingReviewRepository>();
builder.Services.AddScoped<ITrainingReviewService, TrainingReviewService>();
builder.Services.AddScoped<ILecturerService, LecturerService>();
builder.Services.AddScoped<ITrainingRepository, TrainingRepository>();
builder.Services.AddScoped<ILecturerRepository, LecturerRepository>();
builder.Services.AddAutoMapper(typeof(APIMapperProfile), typeof(BusinessMapperProfile));


var app = builder.Build();

app.UseMiddleware<ErrorHandlerMiddleware>();

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
