using CampaignManager.Dto;

namespace CampaignManager.Service
{
    [Command("create_order")]
    public class CreateOrderCommand : ICommand
    {
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;

        public CreateOrderCommand(IOrderService orderService, IProductService productService)
        {
            _orderService = orderService;
            _productService = productService;
        }

        public string Execute(params object[] parameters)
        {
            if (parameters.Length < 2) return "Invalid parameters";
            
            var productCode = parameters[0].ToString();
            var quantity = int.Parse(parameters[1].ToString());
            var productInfo = _productService.GetInfo(productCode);
            var price = productInfo.Data.Price * quantity;
            
            var data = new OrderDto
            {
                ProductCode = productCode,
                Quantity = quantity,
                Price = price
            };

            var response = _orderService.Create(data);

            return response.Success ? $"Order created; Product {data.ProductCode}, Quantity {data.Quantity}" : string.Empty;
        }
    }
}