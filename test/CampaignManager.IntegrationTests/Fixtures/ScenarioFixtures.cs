using System;
using CampaignManager.Service;
using CampaignManager.UnitOfWork;

namespace CampaignManager.IntegrationTests
{
    public class ScenarioFixtures : IDisposable
    {
        public ProductService ProductService { get; private set; }
        public OrderService OrderService { get; private set; }
        public CampaignService CampaignService { get; private set; }
        public TimeService TimeService { get; private set; }

        public ScenarioFixtures()
        {
            var uow = new MemoryUnitOfWork();
            
            ProductService = new ProductService(uow);
            TimeService = new TimeService();
            CampaignService = new CampaignService(uow, TimeService);
            OrderService = new OrderService(uow);
            
            var priceCalculatorModel = new PriceCalculatorModel
            {
                ProductService = ProductService,
                CampaignService = CampaignService,
                OrderService = OrderService
            };
            
            var productPriceCalculator = new ProductPriceCalculator(priceCalculatorModel);

            ProductService.OnProductCreated += s => priceCalculatorModel.ProductCode = s;
            CampaignService.OnCampaignCreated += s => priceCalculatorModel.CampaignCode = s;
            TimeService.OnTimeIncreased += productPriceCalculator.Calculate;
        }

        public void Dispose()
        {
            ProductService = null;
            OrderService = null;
            CampaignService = null;
            TimeService = null;
        }
    }
}