using MediatR;

public class GetAllContatosQueryHandler : IRequestHandler<GetAllContatosQuery, List<Contato>>
{
    private readonly IContatoRepository _contatoRepository;

    public GetAllContatosQueryHandler(IContatoRepository contatoRepository)
    {
        _contatoRepository = contatoRepository;
    }

    public async Task<List<Contato>> Handle(GetAllContatosQuery request, CancellationToken cancellationToken)
    {
        return (await _contatoRepository.GetAllAsync()).ToList();
    }
}