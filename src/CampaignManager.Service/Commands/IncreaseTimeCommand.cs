using System;

namespace CampaignManager.Service
{
    [Command("increase_time")]
    public class IncreaseTimeCommand : ICommand
    {        
        private readonly ITimeService _timeService;

        public IncreaseTimeCommand(ITimeService timeService)
        {
            _timeService = timeService;
        }
        
        public string Execute(params object[] parameters)
        {
            if (parameters.Length < 1) return "Invalid parameters";
            
            var time = int.Parse(parameters[0].ToString());
            var response = _timeService.IncreaseTime(time);
            
            return response.Success ? $"Time is {_timeService}" : string.Empty;
        }
    }
}