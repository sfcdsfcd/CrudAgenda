using AutoMapper;

public class ContatoService : IContatoService
{
    private readonly IContatoRepository _contatoRepository;
    private readonly IMapper _mapper;

    public ContatoService(IContatoRepository contatoRepository, IMapper mapper)
    {
        _contatoRepository = contatoRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ContatoDTO>> GetAllAsync()
    {
        var contatos = await _contatoRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<ContatoDTO>>(contatos);
    }

    public async Task<ContatoDTO> GetByIdAsync(int id)
    {
        var contato = await _contatoRepository.GetByIdAsync(id);
        return _mapper.Map<ContatoDTO>(contato);
    }

    public async Task AddAsync(ContatoDTO contatoDto)
    {
        var contato = _mapper.Map<Contato>(contatoDto);
        await _contatoRepository.AddAsync(contato);
    }

    public async Task UpdateAsync(int id, ContatoDTO contatoDto)
    {
        var contato = await _contatoRepository.GetByIdAsync(id);
        if (contato != null)
        {
            _mapper.Map(contatoDto, contato);
            await _contatoRepository.UpdateAsync(contato);
        }
    }

    public async Task DeleteAsync(int id)
    {
        await _contatoRepository.DeleteAsync(id);
    }
}