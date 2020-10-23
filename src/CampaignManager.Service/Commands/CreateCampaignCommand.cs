using System;
using CampaignManager.Dto;

namespace CampaignManager.Service
{
    [Command("create_campaign")]
    public class CreateCampaignCommand : ICommand
    {
        private readonly ICampaignService _campaignService;

        public CreateCampaignCommand(ICampaignService campaignService)
        {
            _campaignService = campaignService;
        }

        public string Execute(params object[] parameters)
        {
            if (parameters.Length < 5) return "Invalid parameters";
            
            var name = parameters[0].ToString();
            var productCode = parameters[1].ToString();
            var duration = int.Parse(parameters[2].ToString());
            var priceManipulationLimit = int.Parse(parameters[3].ToString());
            var targetSalesCount = int.Parse(parameters[4].ToString());

            var data = new CampaignDto
            {
                Name = name,
                ProductCode = productCode,
                Duration = duration,
                PriceManipulationLimit = priceManipulationLimit,
                TargetSalesCount = targetSalesCount
            };

            var response = _campaignService.Create(data);

            if (response.Success)
            {
                return
                    $"Campaign created; name {data.Name}, product {data.ProductCode}, duration {data.Duration}, limit {data.PriceManipulationLimit}, target sales count {data.TargetSalesCount}";
            }

            return string.Empty;
        }
    }
}