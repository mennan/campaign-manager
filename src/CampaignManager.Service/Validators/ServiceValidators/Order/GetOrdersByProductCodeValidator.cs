using FluentValidation;

namespace CampaignManager.Service
{
    public class GetOrdersByProductCodeValidator : AbstractValidator<string>
    {
        public GetOrdersByProductCodeValidator()
        {
            RuleFor(x => x).NotNull().WithMessage("Product Code is required.");
        }
    }
}