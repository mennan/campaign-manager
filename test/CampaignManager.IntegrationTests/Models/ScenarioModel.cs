namespace CampaignManager.IntegrationTests
{
    public class ScenarioModel
    {
        public string Command { get; set; }
        public object[] Parameters { get; set; }
        public string ExpectedMessage { get; set; }
    }
}