using System;
using CampaignManager.Dto;

namespace CampaignManager.Service
{
    public interface IProductService
    {
        event Action<string> OnProductCreated;
        ServiceResponse Create(ProductDto product);
        ServiceResponse<ProductDto> GetInfo(string productCode);
        ServiceResponse Update(ProductDto product);
    }
}