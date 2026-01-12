using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Application.Common.Interfaces;

namespace Infrastructure.DependencyInjection;

public static class QuestPdfRegistration
{
    /// <summary>
    /// Call this from your Infrastructure DI registration root: services.AddQuestPdf(Configuration);
    /// </summary>
    public static IServiceCollection AddQuestPdf(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<Infrastructure.Pdf.QuestPdfOptions>(configuration.GetSection("QuestPdf"));
        services.AddSingleton<IQuestPdfGenerator, Infrastructure.Pdf.QuestPdfGenerator>();
        return services;
    }
}
