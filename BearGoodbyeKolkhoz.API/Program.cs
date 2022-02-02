using BearGoodbyeKolkhozProject.Data;
using BearGoodbyeKolkhozProject.Data.ConnectDb;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationContext>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//using (BearGoodbyeKolkhozProject.Data.ConnectDb.ApplicationContext db = new BearGoodbyeKolkhozProject.Data.ConnectDb.ApplicationContext()){

//    var qr = new BearGoodbyeKolkhozProject.Data.Entities.Classroom() { City = "Гена", Address = "переулог Мопса"};
//    db.Classroom.Add(qr);
//    db.SaveChanges();
//    db.Dispose();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
