using Microsoft.Extensions.Options;
using PersonApi.Data;
using PersonApi.Helpers.Swagger;
using PersonApi.Helpers.Versioning;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Text.Json.Serialization;
using MappingV1 = PersonApi.Services.Mapping.v1;
using MappingV2 = PersonApi.Services.Mapping.v2;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<LorenzContext>();

builder.Services.AddSingleton<MappingV1.PersonMappingService>();
builder.Services.AddSingleton<MappingV2.PersonMappingService>();

builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
builder.Services.AddTransient<IConfigureOptions<SwaggerUIOptions>, ConfigureSwaggerUIOptions>();

builder.Services.AddControllers()
    .AddJsonOptions(options =>  // show enums as text in swagger 
    {
        options.JsonSerializerOptions
            .Converters
            .Add(new JsonStringEnumConverter());
    });

builder.Services.ConfigureApiVersioning();
builder.Services.AddSwaggerGen();

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();
