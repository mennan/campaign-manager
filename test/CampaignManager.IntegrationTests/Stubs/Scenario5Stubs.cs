using System.Collections;
using System.Collections.Generic;

namespace CampaignManager.IntegrationTests
{
    public class Scenario5Stubs : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new ScenarioModel
                {
                    Command = "create_product",
                    Parameters = new object[] {"P13", 100, 1000},
                    ExpectedMessage = "Product created; code P13, price 100, stock 1000"
                }
            };
            
            yield return new object[]
            {
                new ScenarioModel
                {
                    Command = "create_order",
                    Parameters = new object[] {"P13", 10},
                    ExpectedMessage = "Order created; Product P13, Quantity 10"
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
                    Parameters = new object[] {"C13", "P13", 10, 20, 100},
                    ExpectedMessage =
                        "Campaign created; name C13, product P13, duration 10, limit 20, target sales count 100"
                }
            };
            
            yield return new object[]
            {
                new ScenarioModel
                {
                    Command = "create_order",
                    Parameters = new object[] {"P13", 10},
                    ExpectedMessage = "Order created; Product P13, Quantity 10"
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
                    Parameters = new object[] {"P13"},
                    ExpectedMessage = "Product P13 info; price 100, stock 1000"
                }
            };
            
            yield return new object[]
            {
                new ScenarioModel
                {
                    Command = "get_campaign_info",
                    Parameters = new object[] {"C13"},
                    ExpectedMessage =
                        "Campaign C13 info; Status Active, Target Sales 100, Total Sales 20, Turnover 2000, Average Item Price 100"
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
                    Parameters = new object[] {"P13", 10},
                    ExpectedMessage = "Order created; Product P13, Quantity 10"
                }
            };
            
            yield return new object[]
            {
                new ScenarioModel
                {
                    Command = "get_product_info",
                    Parameters = new object[] {"P13"},
                    ExpectedMessage = "Product P13 info; price 100, stock 1000"
                }
            };
            
            yield return new object[]
            {
                new ScenarioModel
                {
                    Command = "get_campaign_info",
                    Parameters = new object[] {"C13"},
                    ExpectedMessage =
                        "Campaign C13 info; Status Active, Target Sales 100, Total Sales 30, Turnover 3000, Average Item Price 100"
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
                    Parameters = new object[] {"P13", 10},
                    ExpectedMessage = "Order created; Product P13, Quantity 10"
                }
            };
            
            yield return new object[]
            {
                new ScenarioModel
                {
                    Command = "get_product_info",
                    Parameters = new object[] {"P13"},
                    ExpectedMessage = "Product P13 info; price 100, stock 1000"
                }
            };
            
            yield return new object[]
            {
                new ScenarioModel
                {
                    Command = "get_campaign_info",
                    Parameters = new object[] {"C13"},
                    ExpectedMessage =
                        "Campaign C13 info; Status Active, Target Sales 100, Total Sales 40, Turnover 4000, Average Item Price 100"
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
                    Parameters = new object[] {"P13", 10},
                    ExpectedMessage = "Order created; Product P13, Quantity 10"
                }
            };
            
            yield return new object[]
            {
                new ScenarioModel
                {
                    Command = "get_product_info",
                    Parameters = new object[] {"P13"},
                    ExpectedMessage = "Product P13 info; price 100, stock 1000"
                }
            };
            
            yield return new object[]
            {
                new ScenarioModel
                {
                    Command = "get_campaign_info",
                    Parameters = new object[] {"C13"},
                    ExpectedMessage =
                        "Campaign C13 info; Status Active, Target Sales 100, Total Sales 50, Turnover 5000, Average Item Price 100"
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
                    Parameters = new object[] {"P13", 10},
                    ExpectedMessage = "Order created; Product P13, Quantity 10"
                }
            };
            
            yield return new object[]
            {
                new ScenarioModel
                {
                    Command = "get_product_info",
                    Parameters = new object[] {"P13"},
                    ExpectedMessage = "Product P13 info; price 100, stock 1000"
                }
            };
            
            yield return new object[]
            {
                new ScenarioModel
                {
                    Command = "get_campaign_info",
                    Parameters = new object[] {"C13"},
                    ExpectedMessage =
                        "Campaign C13 info; Status Active, Target Sales 100, Total Sales 60, Turnover 6000, Average Item Price 100"
                }
            };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}