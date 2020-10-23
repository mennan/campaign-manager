using FluentValidation;

namespace CampaignManager.Service
{
    public class GetInfoProductValidator : AbstractValidator<string>
    {
        public GetInfoProductValidator()
        {
            RuleFor(x => x).NotNull().WithMessage("Product Code is required.");
        }
    }
}