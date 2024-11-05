using FluentValidation;

public class ContatoValidator : AbstractValidator<ContatoDTO>
{
    public ContatoValidator()
    {
        RuleFor(c => c.Nome).NotEmpty().WithMessage("O nome é obrigatório.");
        RuleFor(c => c.Email).NotEmpty().EmailAddress().WithMessage("O email é obrigatório e deve ser válido.");
        RuleFor(c => c.Telefone).NotEmpty().WithMessage("O telefone é obrigatório.");
    }
}