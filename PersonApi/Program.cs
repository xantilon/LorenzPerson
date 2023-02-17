
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Mvc;
using PersonApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using PersonApi.Helpers.Versioning;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<LorenzContext>(o=> new DbContextOptionsBuilder<LorenzContext>()
    .UseInMemoryDatabase("LorenzDb")
    .EnableSensitiveDataLogging(true)
    .ConfigureWarnings(w => {
        w.Ignore(InMemoryEventId.TransactionIgnoredWarning);
    })
    .LogTo(Console.WriteLine, LogLevel.Information)
);


builder.Services.AddControllers();

builder.Services.ConfigureApiVersioning();
//builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();
