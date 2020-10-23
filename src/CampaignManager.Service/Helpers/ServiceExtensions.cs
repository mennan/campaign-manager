using CampaignManager.Data;
using CampaignManager.Repository;
using CampaignManager.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace CampaignManager.Service
{
    public static class ServiceExtensions
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IContext, MemoryContext>();
            services.AddScoped(typeof(IRepository<>), typeof(MemoryRepository<>));
            services.AddScoped<IUnitOfWork, MemoryUnitOfWork>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddSingleton<ITimeService, TimeService>();
            services.AddScoped<ICampaignService, CampaignService>();
        }
    }
}