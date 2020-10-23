using CampaignManager.Service;
using Xunit;

namespace CampaignManager.IntegrationTests
{
    public class Scenario5CommandTests : IClassFixture<ScenarioFixtures>
    {
        private readonly ScenarioFixtures _fixture;

        public Scenario5CommandTests(ScenarioFixtures fixture)
        {
            _fixture = fixture;
        }

        [Theory]
        [ClassData(typeof(Scenario5Stubs))]
        public void CommandHelper_GivenValidModel_ReturnsExpectedMessage(ScenarioModel scenario)
        {
            var commandHelper = new CommandHelper(_fixture.ProductService, _fixture.CampaignService,
                _fixture.OrderService, _fixture.TimeService);

            var result = commandHelper.GetCommandResult(scenario.Command, scenario.Parameters);

            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal(scenario.ExpectedMessage, result);
        }
    }
}