using System.Collections;
using System.Collections.Generic;

namespace CampaignManager.IntegrationTests
{
    public class Scenario3Stubs : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new ScenarioModel
                {
                    Command = "get_product_info",
                    Parameters = new object[] {},
                    ExpectedMessage = "Invalid parameters"
                }
            };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}