using System.Collections;
using System.Collections.Generic;

namespace CampaignManager.IntegrationTests
{
    public class Scenario2Stubs : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new ScenarioModel
                {
                    Command = "create_product",
                    Parameters = new object[] {"P4", 100, 1000},
                    ExpectedMessage = "Product created; code P4, price 100, stock 1000"
                }
            };

            yield return new object[]
            {
                new ScenarioModel
                {
                    Command = "create_campaign",
                    Parameters = new object[] {"C1", "P4", 5, 20, 100},
                    ExpectedMessage =
                        "Campaign created; name C1, product P4, duration 5, limit 20, target sales count 100"
                }
            };

            yield return new object[]
            {
                new ScenarioModel
                {
                    Command = "get_product_info",
                    Parameters = new object[] {"P4"},
                    ExpectedMessage = "Product P4 info; price 100, stock 1000"
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
                    Command = "create_order",
                    Parameters = new object[] {"P4", 3},
                    ExpectedMessage = "Order created; Product P4, Quantity 3"
                }
            };

            yield return new object[]
            {
                new ScenarioModel
                {
                    Command = "get_product_info",
                    Parameters = new object[] {"P4"},
                    ExpectedMessage = "Product P4 info; price 96, stock 1000"
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
                    Parameters = new object[] {"P4"},
                    ExpectedMessage = "Product P4 info; price 92.16, stock 1000"
                }
            };

            yield return new object[]
            {
                new ScenarioModel
                {
                    Command = "increase_time",
                    Parameters = new object[] {1},
                    ExpectedMessage = "Time is 03:00"
                }
            };

            yield return new object[]
            {
                new ScenarioModel
                {
                    Command = "get_product_info",
                    Parameters = new object[] {"P4"},
                    ExpectedMessage = "Product P4 info; price 88.4736, stock 1000"
                }
            };

            yield return new object[]
            {
                new ScenarioModel
                {
                    Command = "increase_time",
                    Parameters = new object[] {1},
                    ExpectedMessage = "Time is 04:00"
                }
            };

            yield return new object[]
            {
                new ScenarioModel
                {
                    Command = "get_product_info",
                    Parameters = new object[] {"P4"},
                    ExpectedMessage = "Product P4 info; price 84.93466, stock 1000"
                }
            };

            yield return new object[]
            {
                new ScenarioModel
                {
                    Command = "increase_time",
                    Parameters = new object[] {2},
                    ExpectedMessage = "Time is 06:00"
                }
            };

            yield return new object[]
            {
                new ScenarioModel
                {
                    Command = "get_campaign_info",
                    Parameters = new object[] {"C1"},
                    ExpectedMessage =
                        "Campaign C1 info; Status Ended, Target Sales 100, Total Sales 3, Turnover 300, Average Item Price 96"
                }
            };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}