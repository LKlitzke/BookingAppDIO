using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;

namespace BookingAppDio.Core.Web
{
    public static class ConfigurationExtensions
    {
        public static TModel GetOptions<TModel>(this IConfiguration configuration, string sectionName) where TModel : new()
        {
            var model = new TModel();
            configuration.GetSection(sectionName).Bind(model);
            return model;
        }

        public static TModel GetOptions<TModel>(this IServiceCollection service, string sectionName) where TModel : new()
        {
            var model = new TModel();
            var configuration = service.BuildServiceProvider().GetService<IConfiguration>();
            configuration?.GetSection(sectionName).Bind(model);
            return model;
        }

        public static TModel GetOptions<TModel>(this WebApplication app, string sectionName) where TModel : new()
        {
            var model = new TModel();
            app.Configuration?.GetSection(sectionName).Bind(model);
            return model;
        }
    }
}