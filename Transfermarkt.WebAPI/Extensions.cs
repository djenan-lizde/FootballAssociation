using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using Transfermarkt.WebAPI.Formatters;

namespace Transfermarkt.WebAPI
{
    public static class Extensions
    {
        public static IMvcBuilder AddExcelOutputFormatter(this IMvcBuilder builder)
        {
            builder.Services.TryAddEnumerable(
                ServiceDescriptor.Transient<IConfigureOptions<MvcOptions>, ExcelOutputFormatterSetup>());
            return builder;
        }
    }
    public class ExcelOutputFormatterSetup : IConfigureOptions<MvcOptions>
    {
        void IConfigureOptions<MvcOptions>.Configure(MvcOptions options)
        {
            options.OutputFormatters.Add(new ExcelOutputFormatter());
        }
    }
}
