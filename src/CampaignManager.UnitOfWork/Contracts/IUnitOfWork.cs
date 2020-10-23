using System;
using CampaignManager.Entity;
using CampaignManager.Repository;

namespace CampaignManager.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Product> ProductRepository { get; }
        IRepository<Order> OrderRepository { get; }
        IRepository<Campaign> CampaignRepository { get; }
        void Save();
    }
}