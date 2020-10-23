using System;

namespace CampaignManager.Service
{
    public class TimeService : BaseService, ITimeService
    {
        public event Action OnTimeIncreased;
        private int time = 0;

        public ServiceResponse IncreaseTime(int increaseCount)
        {
            var validator = new IncreaseTimeValidator();
            var validationResult = validator.Validate(increaseCount);

            if (!validationResult.IsValid)
            {
                return new ServiceResponse<bool>
                {
                    Success = false,
                    Message = "Model validation errors.",
                    Errors = GetValidationErrors(validationResult)
                };
            }
            
            time += increaseCount;

            OnTimeIncreased?.Invoke();

            return new ServiceResponse
            {
                Success = true,
                Message = "Time increased."
            };
        }

        public ServiceResponse<int> CurrentTime()
        {
            return new ServiceResponse<int>
            {
                Success = true,
                Data = time
            };
        }

        public ServiceResponse ResetTime()
        {
            time = 0;

            return new ServiceResponse
            {
                Success = true,
                Message = "Time reset successfully."
            };
        }

        public override string ToString()
        {
            var formattedTime = $"{time}";
            if (time < 10) formattedTime = $"0{time}";

            return $"{formattedTime}:00";
        }
    }
}