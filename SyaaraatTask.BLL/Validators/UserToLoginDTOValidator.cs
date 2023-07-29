using FluentValidation;
using Task.PersonAddress.DTO.DTOs;

namespace Task.PersonAddress.BLL.Validators;

public class UserToLoginDTOValidator : AbstractValidator<UserToLoginDTO>
{
    public UserToLoginDTOValidator()
    {
        RuleFor(x => x.Email).NotEmpty();
        RuleFor(x => x.Password).NotEmpty();
    }
}
