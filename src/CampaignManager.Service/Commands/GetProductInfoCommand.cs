namespace CampaignManager.Service
{
    [Command("get_product_info")]
    public class GetProductInfoCommand : ICommand
    {
        private readonly IProductService _productService;

        public GetProductInfoCommand(IProductService productService)
        {
            _productService = productService;
        }
        
        public string Execute(params object[] parameters)
        {
            if (parameters.Length < 1) return "Invalid parameters";
            
            var productCode = parameters[0].ToString();
            var response = _productService.GetInfo(productCode);

            if (response.Success)
            {
                var data = response.Data;
                return $"Product {data.ProductCode} info; price {data.Price}, stock {data.Stock}";
            }

            return string.Empty;
        }
    }
}