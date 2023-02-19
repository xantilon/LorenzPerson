using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace PersonApi.Helpers.Versioning;

public static class MvcServiceCollectionExtensions
{
    public static IServiceCollection ConfigureApiVersioning(this IServiceCollection services)
    {
        services.AddApiVersioning(o =>
        {
            o.DefaultApiVersion = new ApiVersion(1, 0);
            o.ReportApiVersions = true;
            o.AssumeDefaultVersionWhenUnspecified = true;
            o.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader()//,
                                                          //new HeaderApiVersionReader("x-api-version"),
                                                          //new MediaTypeApiVersionReader("v")
                                                          );
            o.ApiVersionSelector = new CurrentImplementationApiVersionSelector(o);
        });

        // Add ApiExplorer to discover versions
        services.AddVersionedApiExplorer(setup =>
        {
            setup.GroupNameFormat = "'v'VVV";
            setup.SubstituteApiVersionInUrl = true;
        });
        return services;
    }

}