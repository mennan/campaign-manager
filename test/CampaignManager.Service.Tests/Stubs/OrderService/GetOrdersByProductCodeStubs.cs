using System.Collections;
using System.Collections.Generic;
using CampaignManager.Entity;

namespace CampaignManager.Service.Tests
{
    public class GetOrdersByProductCodeStubs : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new List<Order>
                {
                    new Order
                    {
                        ProductCode = "P11",
                        Quantity = 5
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