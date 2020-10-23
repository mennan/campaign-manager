using System;
using System.Collections.Generic;
using CampaignManager.Dto;
using CampaignManager.Entity;
using CampaignManager.UnitOfWork;

namespace CampaignManager.Service
{
    public class ProductService : BaseService, IProductService
    {
        public event Action<string> OnProductCreated;
        
        private readonly IUnitOfWork _uow;

        public ProductService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ServiceResponse Create(ProductDto product)
        {
            try
            {
                var validator = new CreateProductValidator();
                var validationResult = validator.Validate(product);

                if (!validationResult.IsValid)
                {
                    return new ServiceResponse<bool>
                    {
                        Success = false,
                        Message = "Product not created!",
                        Errors = GetValidationErrors(validationResult)
                    };
                }
                
                var data = new Product
                {
                    ProductCode = product.ProductCode,
                    Price = product.Price,
                    Stock = product.Stock
                };
                _uow.ProductRepository.Add(data);
                _uow.Save();
                
                OnProductCreated?.Invoke(product.ProductCode);

                return new ServiceResponse
                {
                    Success = true,
                    Message = "Product created successfully."
                };
            }
            catch (Exception ex)
            {
                return ex.ToResponse();
            }
        }

        public ServiceResponse<ProductDto> GetInfo(string productCode)
        {
            try
            {
                var validator = new GetInfoProductValidator();
                var validationResult = validator.Validate(productCode);

                if (!validationResult.IsValid)
                {
                    return new ServiceResponse<ProductDto>
                    {
                        Success = false,
                        Message = "User not created!",
                        Errors = GetValidationErrors(validationResult)
                    };
                }
                
                var data = _uow.ProductRepository.FirstOrDefault(x => x.ProductCode == productCode);

                if (data == null)
                {
                    return new ServiceResponse<ProductDto>
                    {
                        Success = false,
                        Message = "Model validation errors."
                    };
                }

                var returnData = MapProductData(data);

                return new ServiceResponse<ProductDto>
                {
                    Success = true,
                    Data = returnData,
                    Message = "Product found."
                };
            }
            catch (Exception ex)
            {
                return ex.ToResponse<ProductDto>();
            }
        }

        public ServiceResponse Update(ProductDto product)
        {
            try
            {
                var validator = new UpdateProductValidator();
                var validationResult = validator.Validate(product);

                if (!validationResult.IsValid)
                {
                    return new ServiceResponse<bool>
                    {
                        Success = false,
                        Message = "Model validation errors.",
                        Errors = GetValidationErrors(validationResult)
                    };
                }
                
                var data = _uow.ProductRepository.FirstOrDefault(x => x.ProductCode == product.ProductCode);

                if (data == null)
                {
                    return new ServiceResponse
                    {
                        Success = false,
                        Message = "Product not found!"
                    };
                }

                var productData = new Product
                {
                    ProductCode = product.ProductCode,
                    Price = product.Price,
                    Stock = product.Stock
                };

                _uow.ProductRepository.Update(productData, x => x.ProductCode == product.ProductCode);
                _uow.Save();

                return new ServiceResponse
                {
                    Success = true,
                    Message = "Product found."
                };
            }
            catch (Exception ex)
            {
                return ex.ToResponse();
            }
        }

        private ProductDto MapProductData(Product data)
        {
            var returnData = new ProductDto
            {
                ProductCode = data.ProductCode,
                Price = data.Price,
                Stock = data.Stock
            };
            return returnData;
        }
    }
}