using FluentValidation;

namespace SFC.Scheme.Application.Features.Scheme.Commands.Create;
public class CreateSchemeCommandValidator : AbstractValidator<CreateSchemeCommand>
{
    public CreateSchemeCommandValidator()
    {
    }
}