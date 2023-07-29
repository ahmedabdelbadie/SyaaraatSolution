using FluentValidation;
using Task.PersonAddress.DTO.DTOs;

namespace Task.PersonAddress.BLL.Validators;

public class UserToRegisterDTOValidator : AbstractValidator<UserToRegisterDTO>
{
    public UserToRegisterDTOValidator()
    {
        RuleFor(x => x.Username).NotEmpty();
        RuleFor(x => x.Password).NotEmpty();
    }
}
