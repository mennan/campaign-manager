using CampaignManager.Dto;
using FluentValidation;

namespace CampaignManager.Service
{
    public class UpdateProductValidator : AbstractValidator<ProductDto>
    {
        public UpdateProductValidator()
        {
            RuleFor(x => x.ProductCode).NotNull().WithMessage("Product code is required.");
        }
    }
}