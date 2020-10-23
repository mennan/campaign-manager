using System;
using CampaignManager.Entity;
using CampaignManager.Repository;

namespace CampaignManager.UnitOfWork
{
    public class MemoryUnitOfWork : IUnitOfWork
    {
        private bool disposed;

        private IRepository<Product> _productRepository;
        private IRepository<Order> _orderRepository;
        private IRepository<Campaign> _campaignRepository;

        public IRepository<Product> ProductRepository => _productRepository ??= new MemoryRepository<Product>();
        public IRepository<Order> OrderRepository => _orderRepository ??= new MemoryRepository<Order>();
        public IRepository<Campaign> CampaignRepository => _campaignRepository ??= new MemoryRepository<Campaign>();

        public void Save()
        {
        }

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                }
            }

            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}