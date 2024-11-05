using MediatR;

public class UpdateContatoCommandHandler : IRequestHandler<UpdateContatoCommand, bool>
{
    private readonly IContatoRepository _contatoRepository;

    public UpdateContatoCommandHandler(IContatoRepository contatoRepository)
    {
        _contatoRepository = contatoRepository;
    }

    public async Task<bool> Handle(UpdateContatoCommand request, CancellationToken cancellationToken)
    {
        var contato = await _contatoRepository.GetByIdAsync(request.Id);
        if (contato == null)
        {
            return false;
        }

        contato.Nome = request.Nome;
        contato.Email = request.Email;
        contato.Telefone = request.Telefone;

        await _contatoRepository.UpdateAsync(contato);
        return true;
    }
}