var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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
BearGoodbyeKolkhozProject.Data.Repositories.AdminRepositories gg = new BearGoodbyeKolkhozProject.Data.Repositories.AdminRepositories();
Console.WriteLine(gg.GetAdminById(1));
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
