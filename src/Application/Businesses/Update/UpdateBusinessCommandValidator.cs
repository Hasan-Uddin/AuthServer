using FluentValidation;

namespace Application.Businesses.Update;

public sealed class UpdateBusinessCommandValidator : AbstractValidator<UpdateBusinessCommand>
{
    public UpdateBusinessCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Business Id is required.");

        RuleFor(x => x.BusinessName)
            .NotEmpty().WithMessage("Business Name is required.");

        RuleFor(x => x.IndustryType)
            .NotEmpty().WithMessage("Industry Type is required.");

        RuleFor(x => x.LogoUrl)
            .NotEmpty().WithMessage("Logo Url is required.")
            .Must(BeUrl).WithMessage("Logo Url must be a valid url.")
            .MaximumLength(255).WithMessage("Url must not exceed 255 char");

        RuleFor(x => x.Status)
            .IsInEnum().WithMessage("Status must be either Active or Inactive.");
    }

    private static bool BeUrl(string x)
    {
        try
        {
            var uri = new Uri(x);
            // Check that it's an absolute URL
            return uri.IsAbsoluteUri &&
                    (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps);
        }
        catch
        {
            return false;
        }
    }
}
