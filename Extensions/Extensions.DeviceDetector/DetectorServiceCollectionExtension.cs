using Microsoft.Extensions.DependencyInjection;

namespace Extensions.DeviceDetector
{
    public static class DetectorServiceCollectionExtension
    {
        public static IServiceCollection AddDeviceDetector(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddScoped<IDetector, Detector>();
            return services;
        }
    }
}