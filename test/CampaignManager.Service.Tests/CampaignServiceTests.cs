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
    public class CampaignServiceTests
    {
        private readonly Mock<IUnitOfWork> _context;
        private readonly Mock<ITimeService> _timeService;
        private readonly Mock<IRepository<Campaign>> _repository;

        public CampaignServiceTests()
        {
            _context = new Mock<IUnitOfWork>();
            _timeService = new Mock<ITimeService>();
            _repository = new Mock<IRepository<Campaign>>();

            _timeService.Setup(x => x.CurrentTime()).Returns(new ServiceResponse<int> {Success = true, Data = 1});
        }

        [Fact]
        public void Create_GivenValidModel_ReturnSuccess()
        {
            _repository.Setup(c => c.Add(It.IsAny<Campaign>()));
            _context.Setup(c => c.CampaignRepository).Returns(_repository.Object);

            var service = new CampaignService(_context.Object, _timeService.Object);
            var data = new CampaignDto
            {
                Name = "Phone Campaign",
                ProductCode = "P11",
                Duration = 10,
                PriceManipulationLimit = 20,
                TargetSalesCount = 1000
            };

            var response = service.Create(data);

            Assert.NotNull(response);
            Assert.True(response.Success);
        }

        [Theory]
        [ClassData(typeof(GetInfoStubs))]
        public void GetInfo_GivenValidModel_ReturnsNoCampaign(List<Campaign> campaigns)
        {
            _repository.Setup(c => c.FirstOrDefault(It.IsAny<Func<Campaign, bool>>()))
                .Returns((Func<Campaign, bool> predicate) => campaigns.FirstOrDefault(predicate));
            _context.Setup(c => c.CampaignRepository).Returns(_repository.Object);

            var service = new CampaignService(_context.Object, _timeService.Object);
            var response = service.GetInfo("Computer Campaign");

            Assert.NotNull(response);
            Assert.False(response.Success);
            Assert.Null(response.Data);
        }

        [Theory]
        [ClassData(typeof(GetInfoStubs))]
        public void GetInfo_GivenValidModel_ReturnsCampaign(List<Campaign> campaigns)
        {
            _repository.Setup(c => c.FirstOrDefault(It.IsAny<Func<Campaign, bool>>()))
                .Returns((Func<Campaign, bool> predicate) => campaigns.FirstOrDefault(predicate));
            _context.Setup(c => c.CampaignRepository).Returns(_repository.Object);

            var service = new CampaignService(_context.Object, _timeService.Object);
            var response = service.GetInfo("Phone Campaign");

            Assert.NotNull(response);
            Assert.True(response.Success);
            Assert.NotNull(response.Data);
        }
    }
}