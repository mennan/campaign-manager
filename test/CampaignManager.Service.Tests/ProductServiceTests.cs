using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CampaignManager.Data;
using CampaignManager.Dto;
using CampaignManager.Entity;
using CampaignManager.Repository;
using CampaignManager.UnitOfWork;
using Moq;
using Xunit;

namespace CampaignManager.Service.Tests
{
    public class ProductServiceTests
    {
        private readonly Mock<IUnitOfWork> _context;
        private readonly Mock<IRepository<Product>> _repository;

        public ProductServiceTests()
        {
            _context = new Mock<IUnitOfWork>();
            _repository = new Mock<IRepository<Product>>();
        }
        
        [Fact]
        public void Create_GivenValidModel_ReturnSuccess()
        {
            _repository.Setup(c => c.Add(It.IsAny<Product>()));
            _context.Setup(c => c.ProductRepository).Returns(_repository.Object);
            var service = new ProductService(_context.Object);
            var data = new ProductDto
            {
                ProductCode = "P11",
                Price = 100,
                Stock = 1000
            };

            var response = service.Create(data);

            Assert.NotNull(response);
            Assert.True(response.Success);
        }

        [Fact]
        public void GetInfo_GivenValidModel_ReturnsNoProduct()
        {
            var service = new ProductService(_context.Object);
            var response = service.GetInfo("P11");

            Assert.NotNull(response);
            Assert.False(response.Success);
            Assert.Null(response.Data);
        }

        [Theory]
        [ClassData(typeof(GetInfoSuccessStubs))]
        public void GetInfo_GivenValidModel_ReturnsSuccess(List<Product> products)
        {
            _repository.Setup(c => c.FirstOrDefault(It.IsAny<Func<Product, bool>>())).Returns(
                (Func<Product, bool> predicate) => products.FirstOrDefault(predicate));
            _context.Setup(c => c.ProductRepository).Returns(_repository.Object);
            var service = new ProductService(_context.Object);

            var data = new ProductDto
            {
                ProductCode = "P11",
                Price = 100,
                Stock = 1000
            };
            service.Create(data);

            var response = service.GetInfo("P11");

            Assert.NotNull(response);
            Assert.True(response.Success);
            Assert.NotNull(response.Data);
        }
    }
}