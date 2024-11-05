using MediatR;

public class DeleteContatoCommandHandler : IRequestHandler<DeleteContatoCommand, bool>
{
    private readonly IContatoRepository _contatoRepository;

    public DeleteContatoCommandHandler(IContatoRepository contatoRepository)
    {
        _contatoRepository = contatoRepository;
    }

    public async Task<bool> Handle(DeleteContatoCommand request, CancellationToken cancellationToken)
    {
        var contato = await _contatoRepository.GetByIdAsync(request.Id);
        if (contato == null)
        {
            return false;
        }

        await _contatoRepository.DeleteAsync(contato);
        return true;
    }
}