using System;
using CampaignManager.Dto;
using CampaignManager.Entity;
using CampaignManager.UnitOfWork;

namespace CampaignManager.Service
{
    public class CampaignService : BaseService, ICampaignService
    {
        public event Action<string> OnCampaignCreated;
        private readonly IUnitOfWork _uow;
        private readonly ITimeService _timeService;

        public CampaignService(IUnitOfWork uow, ITimeService timeService)
        {
            _uow = uow;
            _timeService = timeService;
        }


        public ServiceResponse Create(CampaignDto model)
        {
            try
            {
                var validator = new CreateCampaignValidator();
                var validationResult = validator.Validate(model);

                if (!validationResult.IsValid)
                {
                    return new ServiceResponse<bool>
                    {
                        Success = false,
                        Message = "Campaign not created!",
                        Errors = GetValidationErrors(validationResult)
                    };
                }
                
                var data = new Campaign
                {
                    Name = model.Name,
                    ProductCode = model.ProductCode,
                    Duration = model.Duration,
                    PriceManipulationLimit = model.PriceManipulationLimit,
                    TotalSalesCount = model.TargetSalesCount
                };

                _uow.CampaignRepository.Add(data);
                _uow.Save();
                
                OnCampaignCreated?.Invoke(model.Name);

                return new ServiceResponse
                {
                    Success = true,
                    Message = "Campaign created successfully."
                };
            }
            catch (Exception ex)
            {
                return ex.ToResponse();
            }
        }

        public ServiceResponse<CampaignInfoDto> GetInfo(string name)
        {
            try
            {
                var validator = new GetInfoValidator();
                var validationResult = validator.Validate(name);

                if (!validationResult.IsValid)
                {
                    return new ServiceResponse<CampaignInfoDto>
                    {
                        Success = false,
                        Message = "Model validation errors.",
                        Errors = GetValidationErrors(validationResult)
                    };
                }
                
                var campaign = _uow.CampaignRepository.FirstOrDefault(x => x.Name == name);

                if (campaign == null)
                {
                    return new ServiceResponse<CampaignInfoDto>
                    {
                        Success = false,
                        Message = "Campaign not found!"
                    };
                }

                var returnData = MapCampaignInfoData(campaign);

                return new ServiceResponse<CampaignInfoDto>
                {
                    Success = true,
                    Data = returnData,
                    Message = "Campaign found."
                };
            }
            catch (Exception ex)
            {
                return ex.ToResponse<CampaignInfoDto>();
            }
        }

        private CampaignInfoDto MapCampaignInfoData(Campaign campaign)
        {
            var returnData = new CampaignInfoDto
            {
                Name = campaign.Name,
                ProductCode = campaign.ProductCode,
                Duration = campaign.Duration,
                PriceManipulationLimit = campaign.PriceManipulationLimit,
                TargetSalesCount = campaign.TotalSalesCount,
                CampaignStatus = GetCampaignStatus(campaign.Duration)
            };
            return returnData;
        }

        private CampaignStatuses GetCampaignStatus(int duration)
        {
            var currentTime = _timeService.CurrentTime().Data;

            return currentTime <= duration ? CampaignStatuses.Active : CampaignStatuses.Ended;
        }
    }
}