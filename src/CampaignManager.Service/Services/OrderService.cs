using System;
using System.Collections.Generic;
using System.Linq;
using CampaignManager.Dto;
using CampaignManager.Entity;
using CampaignManager.UnitOfWork;

namespace CampaignManager.Service
{
    public class OrderService : BaseService, IOrderService
    {
        private readonly IUnitOfWork _uow;

        public OrderService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ServiceResponse Create(OrderDto order)
        {
            try
            {
                var validator = new CreateOrderValidator();
                var validationResult = validator.Validate(order);

                if (!validationResult.IsValid)
                {
                    return new ServiceResponse<bool>
                    {
                        Success = false,
                        Message = "Order not created!",
                        Errors = GetValidationErrors(validationResult)
                    };
                }

                var data = new Order
                {
                    ProductCode = order.ProductCode,
                    Quantity = order.Quantity,
                    Price = order.Price
                };
                _uow.OrderRepository.Add(data);
                _uow.Save();

                return new ServiceResponse
                {
                    Success = true,
                    Message = "Order created successfully."
                };
            }
            catch (Exception ex)
            {
                return ex.ToResponse();
            }
        }

        public ServiceResponse<List<OrderDto>> GetOrdersByProductCode(string productCode)
        {
            try
            {
                var validator = new GetOrdersByProductCodeValidator();
                var validationResult = validator.Validate(productCode);

                if (!validationResult.IsValid)
                {
                    return new ServiceResponse<List<OrderDto>>
                    {
                        Success = false,
                        Message = "Model validation errors.",
                        Errors = GetValidationErrors(validationResult)
                    };
                }

                var orders = _uow.OrderRepository.Find(x => x.ProductCode == productCode);
                var returnData = orders.Select(x => new OrderDto
                {
                    ProductCode = x.ProductCode,
                    Quantity = x.Quantity,
                    Price = x.Price
                }).ToList();

                return new ServiceResponse<List<OrderDto>>
                {
                    Success = true,
                    Data = returnData,
                    Message = "Orders listed."
                };
            }
            catch (Exception ex)
            {
                return ex.ToResponse<List<OrderDto>>();
            }
        }
    }
}