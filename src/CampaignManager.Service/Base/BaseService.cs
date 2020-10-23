using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;

namespace CampaignManager.Service
{
    public class BaseService
    {
        protected List<string> GetValidationErrors(ValidationResult result) =>
            result.Errors.Select(x => x.ErrorMessage).ToList();
    }
}