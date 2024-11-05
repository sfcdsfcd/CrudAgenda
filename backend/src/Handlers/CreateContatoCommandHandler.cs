using AutoMapper;
using MediatR;

public class CreateContatoCommandHandler : IRequestHandler<CreateContatoCommand, int>
{
    private readonly IContatoRepository _contatoRepository;
    private readonly IMapper _mapper;
    private readonly RabbitMqService _rabbitMqService;

    public CreateContatoCommandHandler(IContatoRepository contatoRepository, IMapper mapper, RabbitMqService rabbitMqService)
    {
        _contatoRepository = contatoRepository;
        _mapper = mapper;
        _rabbitMqService = rabbitMqService;
    }

    public async Task<int> Handle(CreateContatoCommand request, CancellationToken cancellationToken)
    {
        var contato = _mapper.Map<Contato>(request);
        await _contatoRepository.AddAsync(contato);
        return contato.Id;
    }
}