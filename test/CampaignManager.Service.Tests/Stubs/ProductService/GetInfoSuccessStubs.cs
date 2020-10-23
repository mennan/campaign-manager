using System.Collections;
using System.Collections.Generic;
using CampaignManager.Entity;

namespace CampaignManager.Service.Tests
{
    public class GetInfoSuccessStubs : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new List<Product>
                {
                    new Product
                    {
                        ProductCode = "P11",
                        Price = 100,
                        Stock = 1000
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