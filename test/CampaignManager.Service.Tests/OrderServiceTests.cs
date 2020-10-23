using System;
using System.Collections.Generic;
using System.Linq;
using CampaignManager.Dto;
using CampaignManager.Entity;
using CampaignManager.Repository;
using CampaignManager.UnitOfWork;
using Moq;
using Xunit;

namespace CampaignManager.Service.Tests
{
    public class OrderServiceTests
    {
        private readonly Mock<IUnitOfWork> _context;
        private readonly Mock<IRepository<Order>> _repository;
        
        public OrderServiceTests()
        {
            _context = new Mock<IUnitOfWork>();
            _repository = new Mock<IRepository<Order>>();
        }
        
        [Fact]
        public void Create_GivenValidModel_ReturnSuccess()
        {
            _repository.Setup(c => c.Add(It.IsAny<Order>()));
            _context.Setup(c => c.OrderRepository).Returns(_repository.Object);
            var service = new OrderService(_context.Object);
            var data = new OrderDto
            {
                ProductCode = "P11",
                Quantity = 2
            };

            var response = service.Create(data);

            Assert.NotNull(response);
            Assert.True(response.Success);
        }

        [Theory]
        [ClassData(typeof(GetOrdersByProductCodeStubs))]
        public void GetOrdersByProductCode_GivenValidModel_ReturnsNoOrders(List<Order> orders)
        {
            _repository.Setup(c => c.Find(It.IsAny<Func<Order, bool>>()))
                .Returns((Func<Order, bool> predicate) => orders.Where(predicate).AsQueryable());
            _context.Setup(c => c.OrderRepository).Returns(_repository.Object);
            
            var service = new OrderService(_context.Object);
            var response = service.GetOrdersByProductCode("P51");

            Assert.NotNull(response);
            Assert.True(response.Success);
            Assert.Empty(response.Data);
        }
        
        [Theory]
        [ClassData(typeof(GetOrdersByProductCodeStubs))]
        public void GetOrdersByProductCode_GivenValidModel_ReturnsOrders(List<Order> orders)
        {
            _repository.Setup(c => c.Find(It.IsAny<Func<Order, bool>>()))
                .Returns((Func<Order, bool> predicate) => orders.Where(predicate).AsQueryable());
            _context.Setup(c => c.OrderRepository).Returns(_repository.Object);
            
            var service = new OrderService(_context.Object);
            var response = service.GetOrdersByProductCode("P11");

            Assert.NotNull(response);
            Assert.True(response.Success);
            Assert.Single(response.Data);
        }
    }
}