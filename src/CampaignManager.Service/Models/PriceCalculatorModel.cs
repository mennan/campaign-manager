namespace CampaignManager.Service
{
    public class PriceCalculatorModel
    {
        public IProductService ProductService { get; set; }
        public IOrderService OrderService { get; set; }
        public ICampaignService CampaignService { get; set; }
        public string ProductCode { get; set; }
        public string CampaignCode { get; set; }
    }
}