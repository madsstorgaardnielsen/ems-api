using AspNetCoreRateLimit;

namespace ems_api.Configurations;

public static class RateLimitConfig {
    public static void ConfigureRateLimit(this IServiceCollection services) {
        var rules = new List<RateLimitRule> {
            new RateLimitRule {
                Endpoint = "*",
                Limit = 1,
                Period = "1s"
            }
        };
        services.Configure<IpRateLimitOptions>(options => { options.GeneralRules = rules; });
        services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
        services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
        services.AddSingleton<IProcessingStrategy, AsyncKeyLockProcessingStrategy>();
        services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
    }
}