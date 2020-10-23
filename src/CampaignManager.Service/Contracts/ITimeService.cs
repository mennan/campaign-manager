using System;

namespace CampaignManager.Service
{
    public interface ITimeService
    {
        event Action OnTimeIncreased;
        ServiceResponse IncreaseTime(int increaseCount);
        ServiceResponse<int> CurrentTime();
        ServiceResponse ResetTime();
    }
}