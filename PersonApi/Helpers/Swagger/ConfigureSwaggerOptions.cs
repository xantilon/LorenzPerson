
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace PersonApi.Helpers.Swagger;

public class ConfigureSwaggerOptions
     : IConfigureNamedOptions<SwaggerGenOptions>
{
    private readonly IApiVersionDescriptionProvider _provider;
    public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider) => _provider = provider;

    /// <summary>
    /// Configure each API discovered for Swagger Documentation
    /// </summary>
    /// <param name="options"></param>
    public void Configure(SwaggerGenOptions c)
    {
        // add swagger document for every API version discovered
        foreach (ApiVersionDescription description in _provider.ApiVersionDescriptions)
        {
            c.SwaggerDoc(
                description.GroupName,
                CreateInfoForApiVersion(description)
            );
        }
    }

    /// <summary>
    /// Configure Swagger Options. Inherited from the Interface
    /// </summary>
    /// <param name="name"></param>
    /// <param name="options"></param>
    public void Configure(string? name, SwaggerGenOptions options)
    {
        Configure(options);
    }

    /// <summary>
    /// Create information about the version of the API
    /// </summary>
    /// <param name="description"></param>
    /// <returns>Information about the API</returns>
    private OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription desc)
    {
        var info = new OpenApiInfo()
        {
            Title = "Lorenz Person API",
            Version = desc.ApiVersion.ToString()
        };
        if (desc.IsDeprecated)
        {
            info.Description += " This API version has been deprecated. Please use one of the new APIs available from the explorer.";
        }
        return info;
    }
}
