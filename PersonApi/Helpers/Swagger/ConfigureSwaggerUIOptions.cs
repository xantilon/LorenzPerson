
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace PersonApi.Helpers.Swagger;

public class ConfigureSwaggerUIOptions
     : IConfigureOptions<SwaggerUIOptions>
{
    private readonly IApiVersionDescriptionProvider _provider;
    public ConfigureSwaggerUIOptions(IApiVersionDescriptionProvider provider) => _provider = provider;

    /// <summary>
    /// Configure each API discovered for Swagger Documentation
    /// </summary>
    /// <param name="options"></param>
    public void Configure(SwaggerUIOptions c)
    {
        // add swagger UI endpoint for every API version discovered
        foreach (ApiVersionDescription description in _provider.ApiVersionDescriptions)
        {
            c.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                description.GroupName.ToUpperInvariant());
            c.DefaultModelExpandDepth(0);
            c.DocExpansion(DocExpansion.List);
        }
    }


}
