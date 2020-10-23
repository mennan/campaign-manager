using System.Collections.Generic;
using CampaignManager.Dto;

namespace CampaignManager.Service
{
    public interface IOrderService
    {
        ServiceResponse Create(OrderDto order);
        ServiceResponse<List<OrderDto>> GetOrdersByProductCode(string productCode);
    }
}