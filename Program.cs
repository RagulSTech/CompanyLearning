using LearningCoreAPI.CQRSMethods.Commands.CreateEmployees;
using LearningCoreAPI.Data;
using LearningCoreAPI.Model;
using LearningCoreAPI.RepositoryPattern;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MediatR;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbcontext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDbContext<AppDbContextIdentity>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<Bulk_EmployeesDetails,IdentityRole>().AddEntityFrameworkStores<AppDbContextIdentity>().AddDefaultTokenProviders();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateEmployeeCommandHandler).Assembly));

builder.Services.AddScoped<IStudentDatas, StudentDatas>();
builder.Services.AddScoped<IGenericStudentDatas, StudentDatas>();


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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
