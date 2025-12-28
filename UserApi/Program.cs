using Microsoft.EntityFrameworkCore;
using UserApi.Data;
using UserApi.Services;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure; // optional pero helpful for version config

var builder = WebApplication.CreateBuilder(args);

// DB (MySQL)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    )
);

// Services
builder.Services.AddScoped<PersonService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();
app.Run();
