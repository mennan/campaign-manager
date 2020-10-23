using CampaignManager.Dto;
using FluentValidation;

namespace CampaignManager.Service
{
    public class CreateProductValidator : AbstractValidator<ProductDto>
    {
        public CreateProductValidator()
        {
            RuleFor(x => x.ProductCode).NotNull().WithMessage("Product Code is required.");
            RuleFor(x => x.Price).NotNull().WithMessage("Price must be greater than 0.");
        }
    }
}