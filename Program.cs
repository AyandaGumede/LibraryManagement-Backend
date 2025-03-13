using AppDbContext.Namespace;
using Microsoft.EntityFrameworkCore;
using Student.Repo.Interfaces;  
using Student.Repos;  
using Student.Services.Interfaces;  
using Students.Services;  

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext.Namespace.AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IStudentRepository, StudentsRepository>();  
builder.Services.AddScoped<IStudentService, StudentService>();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  //  app.UseSwagger();
//    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
