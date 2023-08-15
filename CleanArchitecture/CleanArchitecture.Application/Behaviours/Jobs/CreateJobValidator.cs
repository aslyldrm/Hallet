

using CleanArchitecture.Core.Features.Jobs.Commands.CreateJob;
using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Behaviours.Jobs
{
    public class CreateJobValidator : AbstractValidator<CreateJobCommandRequest>
    {
        public CreateJobValidator()
        {
            RuleFor(p => p.Title).NotEmpty().NotNull()
                .WithMessage("Please enter Job name")
                .MaximumLength(150)
                .MinimumLength(5)
                .WithMessage("Please enter job title 5 - 150 characters");

            RuleFor(p => p.Price).NotEmpty().NotNull()
                .WithMessage("Please enter a price")
                .Must(p => p >= 0).WithMessage("Please enter price 0 or positive value");


        }
    }
}
