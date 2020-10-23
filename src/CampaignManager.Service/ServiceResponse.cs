using System.Collections.Generic;

namespace CampaignManager.Service
{
    public class ServiceResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }

    }
    
    public class ServiceResponse<T> : ServiceResponse
    {
        public T Data { get; set; }
    }
}