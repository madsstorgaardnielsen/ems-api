using Marvin.Cache.Headers;

namespace ems_api.Configurations;

public static class HttpCacheHeadersConfig {
    public static void ConfigureHttpCacheHeaders(this IServiceCollection services) {
        services.AddResponseCaching();
        services.AddHttpCacheHeaders(
            expirationOptions => {
                expirationOptions.MaxAge = 120;
                expirationOptions.CacheLocation = CacheLocation.Private;
            },
            (validationOptions) => { validationOptions.MustRevalidate = true; }
        );
    }
}