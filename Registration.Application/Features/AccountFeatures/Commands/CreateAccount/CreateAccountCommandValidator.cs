using FluentValidation;
using Registration.Application.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Registration.Application.Features.AccountFeatures.Commands.CreateAccount
{
    public class CreateAccountCommandValidator: AbstractValidator<CreateAccountCommandDTO>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateAccountCommandValidator(IUnitOfWork unitOfWork)
        {
            RuleFor(a => a.FirstName)
                .NotEmpty().WithMessage("First name is required")
                .MaximumLength(20).WithMessage("Maximum number of charachters is: 20")
                .Matches(@"^[a-zA-Z\s]+$").WithMessage("First Name must contain only letters and spaces.");

            RuleFor(a => a.MiddleName)
                .MaximumLength(40).WithMessage("Maximum number of charachters is: 40")
                .Matches(@"^[a-zA-Z\s]+$").WithMessage("Middle Name must contain only letters and spaces.");

            RuleFor(a => a.LastName)
                .NotEmpty().WithMessage("Last name is required")
                .MaximumLength(20).WithMessage("Maximum number of charachters is: 20")
                .Matches(@"^[a-zA-Z\s]+$").WithMessage("Last Name must contain only letters and spaces.");

            RuleFor(a => a.BirthDate)
                .NotEmpty().WithMessage("Birthdate is required")
                .Must(BeAtLeast20YearsOld).WithMessage("You should be at least 20 years old.");

            RuleFor(a => a.MobileNumber)
                .NotEmpty().WithMessage("Mobile is required")
                .Matches(@"^\+201\d{9}$").WithMessage("Mobile number should be in the format +021 165 1581234")
                .Must(EmailUnique).WithMessage("There is another account with the same email.");

            RuleFor(a => a.Email)
            .EmailAddress().WithMessage("Please enter a valid email address.")
            .Must(MobileNumberUnique).WithMessage("There is another account with the same Mobile Number.");

            RuleForEach(a => a.Addresses)
            .SetValidator(new CreateAccountCommandAddressValidator());
            _unitOfWork = unitOfWork;
        }

        private bool BeAtLeast20YearsOld(DateTime birthDate)
        {
            var today = DateTime.Today;
            var age = today.Year - birthDate.Year;

            if (birthDate > today.AddYears(-age))
            {
                age--;
            }

            return age >= 20;
        }

        private bool EmailUnique(string email)
        {
            bool isEmailUnique = _unitOfWork.Accounts.IsEmailUnique(email);
            return isEmailUnique;
        }

        private bool MobileNumberUnique(string mobileNumber)
        {
            bool isMobileNumberUnique = _unitOfWork.Accounts.IsMobileNumberUnique(mobileNumber);
            return isMobileNumberUnique;
        }
    }

}
