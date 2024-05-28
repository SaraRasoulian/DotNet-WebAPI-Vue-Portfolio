using Application.Service;
using Application.Service.Interfaces;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IProfileService, ProfileService>();
        services.AddScoped<IEducationService, EducationService>();
        services.AddScoped<IExperienceService, ExperienceService>();
        services.AddScoped<ISocialLinkService, SocialLinkService>();
        services.AddScoped<IMessageService, MessageService>();
        services.AddScoped<IIdentityService, IdentityService>();

        return services;
    }
}