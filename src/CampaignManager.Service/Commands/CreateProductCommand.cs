using System;
using CampaignManager.Dto;

namespace CampaignManager.Service
{
    [Command("create_product")]
    public class CreateProductCommand : ICommand
    {
        private readonly IProductService _productService;

        public CreateProductCommand(IProductService productService)
        {
            _productService = productService;
        }

        public string Execute(params object[] parameters)
        {
            if (parameters.Length < 3) return "Invalid parameters";
            
            var productCode = parameters[0].ToString();
            var price = float.Parse(parameters[1].ToString());
            var stock = int.Parse(parameters[2].ToString());

            var data = new ProductDto
            {
                ProductCode = productCode,
                Price = price,
                Stock = stock
            };

            var response = _productService.Create(data);

            if (response.Success)
            {
                return $"Product created; code {data.ProductCode}, price {data.Price}, stock {data.Stock}";
            }

            return string.Empty;
        }
    }
}