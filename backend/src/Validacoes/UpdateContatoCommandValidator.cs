using FluentValidation;

public class UpdateContatoCommandValidator : AbstractValidator<UpdateContatoCommand>
{
    public UpdateContatoCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty().WithMessage("O ID é obrigatório.");
        RuleFor(c => c.Nome).NotEmpty().WithMessage("O nome é obrigatório.");
        RuleFor(c => c.Email).NotEmpty().EmailAddress().WithMessage("O email é obrigatório e deve ser válido.");
        RuleFor(c => c.Telefone).NotEmpty().WithMessage("O telefone é obrigatório.");
    }
}