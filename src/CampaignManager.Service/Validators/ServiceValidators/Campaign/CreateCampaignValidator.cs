using CampaignManager.Dto;
using FluentValidation;

namespace CampaignManager.Service
{
    public class CreateCampaignValidator : AbstractValidator<CampaignDto>
    {
        public CreateCampaignValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Campaign name is required.");
            RuleFor(x => x.ProductCode).NotEmpty().WithMessage("Product code is required.");
            RuleFor(x => x.Duration).NotEmpty().WithMessage("Duration must be greater than 0.");
            RuleFor(x => x.TargetSalesCount).NotEmpty().WithMessage("Target Sales Count must be greater than 0.");
        }
    }
}