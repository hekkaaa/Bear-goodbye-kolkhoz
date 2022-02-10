using BearGoodbyeKolkhozProject.API.Infrastructure;
using BearGoodbyeKolkhozProject.Business.Processor;
using BearGoodbyeKolkhozProject.Data.ConnectDb;
using BearGoodbyeKolkhozProject.Data.Repo;
using Microsoft.EntityFrameworkCore;

const string? _connStringVariableName = "CONNECTION_STRING";

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
/*Learn more about configuring Swagger/OpenAPI at*/ https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationContext>();

builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<IEventRepository, EventRepository>();

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
