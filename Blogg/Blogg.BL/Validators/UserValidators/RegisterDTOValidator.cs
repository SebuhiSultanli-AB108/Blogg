using Blogg.BL.DTOs.UserDTOs;
using Blogg.Core.Repositories;
using FluentValidation;

namespace Blogg.BL.Validators.UserValidators;

public class RegisterDTOValidator : AbstractValidator<RegisterDTO>
{
    readonly IUserRepository _repository;
    public RegisterDTOValidator(IUserRepository repository)
    {
        _repository = repository;
        RuleFor(x => x.Email)
            .NotEmpty()
            .NotNull()
            .EmailAddress();
        RuleFor(x => x.Username)
            .NotEmpty()
            .NotNull()
            .Must(y => _repository.GetByUsernameOrEmailAsync(y).Result == null)
                .WithMessage("Username already exist");
    }
}