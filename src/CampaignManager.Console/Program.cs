using System;
using System.Collections.Generic;
using CampaignManager.Dto;
using CampaignManager.Service;
using Microsoft.Extensions.DependencyInjection;

namespace CampaignManager.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = ConfigureServices();
            var serviceProvider = services.BuildServiceProvider();

            serviceProvider.GetService<App>().Run();
        }
        
        private static IServiceCollection ConfigureServices()
        {
            var services = new ServiceCollection();
            
            services.ConfigureServices();
            services.AddTransient<App>();
            
            return services;
        }
    }
}