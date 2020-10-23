using System.Linq;

namespace CampaignManager.Service
{
    [Command("get_campaign_info")]
    public class GetCampaignInfoCommand : ICommand
    {
        private readonly ICampaignService _campaignService;
        private readonly IOrderService _orderService;

        public GetCampaignInfoCommand(ICampaignService campaignService, IOrderService orderService)
        {
            _campaignService = campaignService;
            _orderService = orderService;
        }

        public string Execute(params object[] parameters)
        {
            if (parameters.Length < 1) return "Invalid parameters";

            var name = parameters[0].ToString();
            var response = _campaignService.GetInfo(name);

            if (!response.Success) return string.Empty;
            
            var data = response.Data;
            var orders = _orderService.GetOrdersByProductCode(data.ProductCode);
            var orderData = orders.Data;
            var totalSales = orderData.Sum(x => x.Quantity);
            var totalPrices = orderData.Sum(x => x.Price);
            var averageItemPrice = totalPrices / totalSales;
            var turnOver = data.TargetSalesCount * totalSales;

            return
                $"Campaign {data.Name} info; Status {data.CampaignStatus}, Target Sales {data.TargetSalesCount}, Total Sales {totalSales}, Turnover {turnOver}, Average Item Price {averageItemPrice}";

        }
    }
}