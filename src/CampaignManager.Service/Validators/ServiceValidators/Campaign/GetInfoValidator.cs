using FluentValidation;

namespace CampaignManager.Service
{
    public class GetInfoValidator : AbstractValidator<string>
    {
        public GetInfoValidator()
        {
            RuleFor(x => x).NotEmpty().WithMessage("Campaign name is required");
        }
    }
}