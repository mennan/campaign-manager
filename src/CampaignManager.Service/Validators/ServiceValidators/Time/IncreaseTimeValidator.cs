using FluentValidation;

namespace CampaignManager.Service
{
    public class IncreaseTimeValidator : AbstractValidator<int>
    {
        public IncreaseTimeValidator()
        {
            RuleFor(x => x).NotNull().WithMessage("Time must be greater than 0.");
        }
    }
}