using AutoMapper;
using MediatR;

public class GetContatoByIdQueryHandler : IRequestHandler<GetContatoByIdQuery, ContatoDTO>
{
    private readonly IContatoRepository _contatoRepository;
    private readonly IMapper _mapper;

    public GetContatoByIdQueryHandler(IContatoRepository contatoRepository, IMapper mapper)
    {
        _contatoRepository = contatoRepository;
        _mapper = mapper;
    }

    public async Task<ContatoDTO> Handle(GetContatoByIdQuery request, CancellationToken cancellationToken)
    {
        var contato = await _contatoRepository.GetByIdAsync(request.Id);
        return _mapper.Map<ContatoDTO>(contato);
    }
}