using BearGoodbyeKolkhozProject.API.Infrastructure;
using BearGoodbyeKolkhozProject.Business.Processor;
using BearGoodbyeKolkhozProject.Data.ConnectDb;
using BearGoodbyeKolkhozProject.Data.Interfaces;
using BearGoodbyeKolkhozProject.Data.Repo;
using BearGoodbyeKolkhozProject.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using BearGoodbyeKolkhozProject.API;
using BearGoodbyeKolkhozProject.Business.Configuration;
using BearGoodbyeKolkhozProject.Business.Interface;
using BearGoodbyeKolkhozProject.Data.Interfaces;
using BearGoodbyeKolkhozProject.API.Extensions;


const string? _connStringVariableName = "CONNECTION_STRING";

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
/*Learn more about configuring Swagger/OpenAPI at*/ https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationContext>();

var connString = builder.Configuration.GetValue<string>(_connString);

builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connString));

// add service and provider connections here
builder.Services.RegisterProjectService();
builder.Services.RegisterProjectRepository();

builder.Services.AddAutoMapper(typeof(APIMapperProfile), typeof(BusinessMapperProfile));
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<IContactLecturerRepository, ContactLecturerRepository>();
builder.Services.AddScoped<ILecturerRepository, LecturerRepository>();
builder.Services.AddScoped<ITrainingRepository, TrainingRepository>();
builder.Services.AddScoped<ITrainingReviewRepository, TrainingReviewRepository>();

var connString = builder.Configuration.GetValue<string>(_connStringVariableName);
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connString));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<ErrorHandlerMiddleware>();

app.MapControllers();

app.Run();