using AutomationBotAPI.DataContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("ConnectionMysql");

builder.Services.AddDbContext<AutomationDBContext>(options => options.UseMySql(
    connectionString,
    ServerVersion.AutoDetect(connectionString)
    )
);

builder.Services.AddCors( options => 
    options.AddPolicy("AllowAnyOrigin", builder =>
    {
        builder.AllowAnyOrigin()
            .WithMethods("GET", "POST")
            .AllowAnyHeader();
    })
);
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

app.UseCors(builder => builder.AllowAnyOrigin().WithMethods("GET", "POST").AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

app.Run();
