using System.Collections.Generic;
using CampaignManager.Entity;

namespace CampaignManager.Data
{
    public class MemoryContext : IContext
    {
        public List<Product> Products { get; set; } = new List<Product>();
        public List<Order> Orders { get; set; } = new List<Order>();
        public List<Campaign> Campaigns { get; set; } = new List<Campaign>();

        public List<T> Set<T>()
        {
            List<T> obj = null;
            var properties = typeof(MemoryContext).GetProperties();

            foreach (var property in properties)
            {
                var type = property.PropertyType;
                if (!type.IsGenericType || type.GetGenericTypeDefinition() != typeof(List<>)) continue;
                
                var itemType = type.GetGenericArguments()[0];

                if (!itemType.IsAssignableFrom(typeof(T))) continue;
                
                obj = (List<T>)property.GetValue(this, null);
                break;
            }

            return obj;
        }
    }
}