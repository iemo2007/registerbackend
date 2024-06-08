using FluentValidation;

namespace Registration.Application.Features.AccountFeatures.Commands.CreateAccount
{
    public class CreateAccountCommandAddressValidator : AbstractValidator<CreateAccountCommandAddressDTO>
    {
        public CreateAccountCommandAddressValidator()
        {
            RuleFor(address => address.Street)
                .NotEmpty().WithMessage("Street is required.")
                .MaximumLength(200).WithMessage("The maximum no. of charachters is: 200");

            RuleFor(address => address.BuildingNumber)
                .NotEmpty().WithMessage("Building number is required.");

            RuleFor(address => address.FlatNumber)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(0).WithMessage("Flat number must be greater than 0");

            RuleFor(address => address.CityId)
                .NotEmpty().WithMessage("City is required.");

            RuleFor(address => address.GovernateId)
                .NotEmpty().WithMessage("Governate is required.");
        }
    }

}
