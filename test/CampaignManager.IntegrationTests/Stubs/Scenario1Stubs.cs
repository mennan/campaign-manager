using System.Collections;
using System.Collections.Generic;

namespace CampaignManager.IntegrationTests
{
    public class Scenario1Stubs : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new ScenarioModel
                {
                    Command = "create_product",
                    Parameters = new object[] {"P11", 100, 1000},
                    ExpectedMessage = "Product created; code P11, price 100, stock 1000"
                }
            };

            yield return new object[]
            {
                new ScenarioModel
                {
                    Command = "create_campaign",
                    Parameters = new object[] {"C11", "P11", 10, 20, 100},
                    ExpectedMessage =
                        "Campaign created; name C11, product P11, duration 10, limit 20, target sales count 100"
                }
            };

            yield return new object[]
            {
                new ScenarioModel
                {
                    Command = "create_order",
                    Parameters = new object[] {"P11", 10},
                    ExpectedMessage = "Order created; Product P11, Quantity 10"
                }
            };

            yield return new object[]
            {
                new ScenarioModel
                {
                    Command = "get_product_info",
                    Parameters = new object[] {"P11"},
                    ExpectedMessage = "Product P11 info; price 100, stock 1000"
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
                    Parameters = new object[] {"P11", 15},
                    ExpectedMessage = "Order created; Product P11, Quantity 15"
                }
            };

            yield return new object[]
            {
                new ScenarioModel
                {
                    Command = "get_product_info",
                    Parameters = new object[] {"P11"},
                    ExpectedMessage = "Product P11 info; price 98, stock 1000"
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
                    Command = "create_order",
                    Parameters = new object[] {"P11", 20},
                    ExpectedMessage = "Order created; Product P11, Quantity 20"
                }
            };

            yield return new object[]
            {
                new ScenarioModel
                {
                    Command = "get_product_info",
                    Parameters = new object[] {"P11"},
                    ExpectedMessage = "Product P11 info; price 98, stock 1000"
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
                    Command = "create_order",
                    Parameters = new object[] {"P11", 25},
                    ExpectedMessage = "Order created; Product P11, Quantity 25"
                }
            };

            yield return new object[]
            {
                new ScenarioModel
                {
                    Command = "get_product_info",
                    Parameters = new object[] {"P11"},
                    ExpectedMessage = "Product P11 info; price 98, stock 1000"
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
                    Command = "create_order",
                    Parameters = new object[] {"P11", 30},
                    ExpectedMessage = "Order created; Product P11, Quantity 30"
                }
            };

            yield return new object[]
            {
                new ScenarioModel
                {
                    Command = "get_product_info",
                    Parameters = new object[] {"P11"},
                    ExpectedMessage = "Product P11 info; price 98, stock 1000"
                }
            };

            yield return new object[]
            {
                new ScenarioModel
                {
                    Command = "increase_time",
                    Parameters = new object[] {1},
                    ExpectedMessage = "Time is 05:00"
                }
            };

            yield return new object[]
            {
                new ScenarioModel
                {
                    Command = "create_order",
                    Parameters = new object[] {"P11", 30},
                    ExpectedMessage = "Order created; Product P11, Quantity 30"
                }
            };

            yield return new object[]
            {
                new ScenarioModel
                {
                    Command = "get_product_info",
                    Parameters = new object[] {"P11"},
                    ExpectedMessage = "Product P11 info; price 98, stock 1000"
                }
            };

            yield return new object[]
            {
                new ScenarioModel
                {
                    Command = "increase_time",
                    Parameters = new object[] {1},
                    ExpectedMessage = "Time is 06:00"
                }
            };

            yield return new object[]
            {
                new ScenarioModel
                {
                    Command = "create_order",
                    Parameters = new object[] {"P11", 25},
                    ExpectedMessage = "Order created; Product P11, Quantity 25"
                }
            };

            yield return new object[]
            {
                new ScenarioModel
                {
                    Command = "get_product_info",
                    Parameters = new object[] {"P11"},
                    ExpectedMessage = "Product P11 info; price 99.96, stock 1000"
                }
            };

            yield return new object[]
            {
                new ScenarioModel
                {
                    Command = "increase_time",
                    Parameters = new object[] {1},
                    ExpectedMessage = "Time is 07:00"
                }
            };

            yield return new object[]
            {
                new ScenarioModel
                {
                    Command = "create_order",
                    Parameters = new object[] {"P11", 20},
                    ExpectedMessage = "Order created; Product P11, Quantity 20"
                }
            };

            yield return new object[]
            {
                new ScenarioModel
                {
                    Command = "get_product_info",
                    Parameters = new object[] {"P11"},
                    ExpectedMessage = "Product P11 info; price 101.9592, stock 1000"
                }
            };

            yield return new object[]
            {
                new ScenarioModel
                {
                    Command = "increase_time",
                    Parameters = new object[] {1},
                    ExpectedMessage = "Time is 08:00"
                }
            };

            yield return new object[]
            {
                new ScenarioModel
                {
                    Command = "create_order",
                    Parameters = new object[] {"P11", 15},
                    ExpectedMessage = "Order created; Product P11, Quantity 15"
                }
            };

            yield return new object[]
            {
                new ScenarioModel
                {
                    Command = "get_product_info",
                    Parameters = new object[] {"P11"},
                    ExpectedMessage = "Product P11 info; price 103.99838, stock 1000"
                }
            };

            yield return new object[]
            {
                new ScenarioModel
                {
                    Command = "increase_time",
                    Parameters = new object[] {1},
                    ExpectedMessage = "Time is 09:00"
                }
            };

            yield return new object[]
            {
                new ScenarioModel
                {
                    Command = "create_order",
                    Parameters = new object[] {"P11", 10},
                    ExpectedMessage = "Order created; Product P11, Quantity 10"
                }
            };

            yield return new object[]
            {
                new ScenarioModel
                {
                    Command = "get_product_info",
                    Parameters = new object[] {"P11"},
                    ExpectedMessage = "Product P11 info; price 106.078354, stock 1000"
                }
            };

            yield return new object[]
            {
                new ScenarioModel
                {
                    Command = "increase_time",
                    Parameters = new object[] {1},
                    ExpectedMessage = "Time is 10:00"
                }
            };

            yield return new object[]
            {
                new ScenarioModel
                {
                    Command = "get_product_info",
                    Parameters = new object[] {"P11"},
                    ExpectedMessage = "Product P11 info; price 108.19992, stock 1000"
                }
            };

            yield return new object[]
            {
                new ScenarioModel
                {
                    Command = "increase_time",
                    Parameters = new object[] {1},
                    ExpectedMessage = "Time is 11:00"
                }
            };

            yield return new object[]
            {
                new ScenarioModel
                {
                    Command = "get_campaign_info",
                    Parameters = new object[] {"C11"},
                    ExpectedMessage =
                        "Campaign C11 info; Status Ended, Target Sales 100, Total Sales 200, Turnover 20000, Average Item Price 99.59472"
                }
            };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}