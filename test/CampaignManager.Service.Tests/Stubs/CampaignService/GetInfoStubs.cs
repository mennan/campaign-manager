using System.Collections;
using System.Collections.Generic;
using CampaignManager.Entity;

namespace CampaignManager.Service.Tests
{
    public class GetInfoStubs : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new List<Campaign>
                {
                    new Campaign
                    {
                        Name = "Phone Campaign",
                        ProductCode = "P11",
                        Duration = 10,
                        PriceManipulationLimit = 20,
                        TotalSalesCount = 1000
                    }
                }
            };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}