using System;
using System.Collections.Generic;

namespace CampaignManager.Service
{
    public static class Extensions
    {
        public static ServiceResponse ToResponse(this Exception ex)
        {
            return new ServiceResponse
            {
                Success = false,
                Message = "Internal Error",
                Errors = new List<string> {ex.Message}
            };
        }
        
        public static ServiceResponse<T> ToResponse<T>(this Exception ex)
        {
            return new ServiceResponse<T>
            {
                Success = false,
                Message = "Internal Error",
                Errors = new List<string> {ex.Message}
            };
        }
    }
}