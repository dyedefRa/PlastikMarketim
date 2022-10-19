using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Volo.Abp;

namespace PlastikMarketim
{
    public class PlastikMarketimWebTestStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication<PlastikMarketimWebTestModule>();
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            app.InitializeApplication();
        }
    }
}