using System;
using CampaignManager.Dto;

namespace CampaignManager.Service
{
    public interface ICampaignService
    {
        event Action<string> OnCampaignCreated;
        ServiceResponse Create(CampaignDto model);
        ServiceResponse<CampaignInfoDto> GetInfo(string name);
    }
}