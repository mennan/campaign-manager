using System;
using System.Collections.Generic;
using System.Linq;
using CampaignManager.Dto;

namespace CampaignManager.Service
{
    public class ProductPriceCalculator
    {
        private readonly PriceCalculatorModel _model;
        private const int MinimumSalesRatio = 15;
        private const int MaximumSalesRatio = 35;

        public ProductPriceCalculator(PriceCalculatorModel model)
        {
            _model = model;
        }

        public void Calculate()
        {
            var productInfo = _model.ProductService.GetInfo(_model.ProductCode);
            var campaignInfo = _model.CampaignService.GetInfo(_model.CampaignCode);

            if (!productInfo.Success || !campaignInfo.Success) return;
            
            var productData = productInfo.Data;
            var campaignData = campaignInfo.Data;
            var priceRatios = CalculateRatios(campaignData, productData);
            var minimumProductPrice = productData.Price - priceRatios.PriceManipulationRatio;
            var maximumProductPrice = productData.Price + priceRatios.PriceManipulationRatio;
                
            var newProductPrice = CalculateNewPrice(campaignData, productData, priceRatios, minimumProductPrice, maximumProductPrice);

            if (productData.Price == newProductPrice) return;
                
            productData.Price = newProductPrice;
            _model.ProductService.Update(productData);
        }

        private PriceRatio CalculateRatios(CampaignInfoDto campaignData, ProductDto productData)
        {
            var hourlyManipulationRatio = campaignData.PriceManipulationLimit / campaignData.Duration;
            var priceManipulationRatio = productData.Price * campaignData.PriceManipulationLimit / 100;

            var priceRatios = new PriceRatio
            {
                HourlyManipulationRatio = hourlyManipulationRatio,
                PriceManipulationRatio = priceManipulationRatio
            };

            return priceRatios;
        }
        
        private float CalculateNewPrice(CampaignInfoDto campaignData, ProductDto productData,
            PriceRatio priceRatios, float minimumProductPrice, float maximumProductPrice)
        {
            var orderInfo = _model.OrderService.GetOrdersByProductCode(productData.ProductCode);
            var orders = orderInfo.Data;

            var totalSales = orders.Sum(x => x.Quantity);
            var ratio = totalSales * 100 / campaignData.TargetSalesCount;
            var manipulationAmount = productData.Price * priceRatios.HourlyManipulationRatio / 100;
            var newProductPrice = productData.Price;

            if (ratio <= MinimumSalesRatio && productData.Price >= minimumProductPrice)
            {
                newProductPrice -= manipulationAmount;
            }
            else if (ratio >= maximumProductPrice && productData.Price <= maximumProductPrice)
            {
                newProductPrice += manipulationAmount;
            }

            return newProductPrice;
        }

        public class PriceRatio
        {
            public int HourlyManipulationRatio { get; set; }
            public float PriceManipulationRatio { get; set; }
        }
    }
}