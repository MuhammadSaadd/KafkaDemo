using Kafka.Api;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// add the DbContext
builder.Services.AddDbContext<AppDbContext>(
    options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
            o => o
                .UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery))
                .LogTo(Console.WriteLine, LogLevel.Warning)
                .EnableSensitiveDataLogging());

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

app.Run();
