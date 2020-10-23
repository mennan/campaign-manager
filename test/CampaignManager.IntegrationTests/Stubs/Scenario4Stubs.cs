using System.Collections;
using System.Collections.Generic;

namespace CampaignManager.IntegrationTests
{
    public class Scenario4Stubs : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new ScenarioModel
                {
                    Command = "create_product",
                    Parameters = new object[] {"P12", 100, 1000},
                    ExpectedMessage = "Product created; code P12, price 100, stock 1000"
                }
            };

            yield return new object[]
            {
                new ScenarioModel
                {
                    Command = "create_order",
                    Parameters = new object[] {"P12", 10},
                    ExpectedMessage = "Order created; Product P12, Quantity 10"
                }
            };

            yield return new object[]
            {
                new ScenarioModel
                {
                    Command = "increase_time",
                    Parameters = new object[] {1},
                    ExpectedMessage = "Time is 01:00"
                }
            };

            yield return new object[]
            {
                new ScenarioModel
                {
                    Command = "create_campaign",
                    Parameters = new object[] {"C12", "P12", 10, 20, 100},
                    ExpectedMessage =
                        "Campaign created; name C12, product P12, duration 10, limit 20, target sales count 100"
                }
            };

            yield return new object[]
            {
                new ScenarioModel
                {
                    Command = "create_order",
                    Parameters = new object[] {"P12", 10},
                    ExpectedMessage = "Order created; Product P12, Quantity 10"
                }
            };

            yield return new object[]
            {
                new ScenarioModel
                {
                    Command = "increase_time",
                    Parameters = new object[] {1},
                    ExpectedMessage = "Time is 02:00"
                }
            };

            yield return new object[]
            {
                new ScenarioModel
                {
                    Command = "get_product_info",
                    Parameters = new object[] {"P12"},
                    ExpectedMessage = "Product P12 info; price 100, stock 1000"
                }
            };

            yield return new object[]
            {
                new ScenarioModel
                {
                    Command = "get_campaign_info",
                    Parameters = new object[] {"C12"},
                    ExpectedMessage =
                        "Campaign C12 info; Status Active, Target Sales 100, Total Sales 20, Turnover 2000, Average Item Price 100"
                }
            };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}