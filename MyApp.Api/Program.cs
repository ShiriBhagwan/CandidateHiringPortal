using Microsoft.EntityFrameworkCore;
using MyApp.Application;
using MyApp.Application.Services.InterviewServices;
using MyApp.Application.Services.UserServices;
using MyApp.Data;
using MyApp.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


var connectionString = builder.Configuration.GetConnectionString("DefaultConnectionString");
builder.Services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(connectionString));

builder.Services.AddScoped<IGenericRepository<Candidate>, GenericRepository<Candidate>>();
builder.Services.AddScoped<IGenericRepository<UserDetails>, GenericRepository<UserDetails>>();
builder.Services.AddScoped<IGenericRepository<Interview>, GenericRepository<Interview>>();
 builder.Services.AddScoped<IGenericRepository<Role>, GenericRepository<Role>>();
builder.Services.AddScoped<ICandidateService, CandidateService>();
builder.Services.AddScoped<IRoleService, RoleServices>();
builder.Services.AddScoped<IInterviewService, InterviewService>();

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
