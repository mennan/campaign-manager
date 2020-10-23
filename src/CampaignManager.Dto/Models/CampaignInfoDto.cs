namespace CampaignManager.Dto
{
    public class CampaignInfoDto
    {
        public string Name { get; set; }
        public string ProductCode { get; set; }
        public int Duration { get; set; }
        public int PriceManipulationLimit { get; set; }
        public int TargetSalesCount { get; set; }
        public CampaignStatuses CampaignStatus { get; set; }
    }

    public enum CampaignStatuses
    {
        Active,
        Ended
    }
}