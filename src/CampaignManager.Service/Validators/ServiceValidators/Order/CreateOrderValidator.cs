using CampaignManager.Dto;
using FluentValidation;

namespace CampaignManager.Service
{
    public class CreateOrderValidator : AbstractValidator<OrderDto>
    {
        public CreateOrderValidator()
        {
            RuleFor(x => x.ProductCode).NotNull().WithMessage("Product Code is required.");
            RuleFor(x => x.Quantity).NotNull().WithMessage("Quantity must be greater than 0.");
            RuleFor(x => x.Price).NotNull().WithMessage("Price must be greater than 0.");
        }
    }
}