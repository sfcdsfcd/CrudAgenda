public interface IContatoService
{
    Task<IEnumerable<ContatoDTO>> GetAllAsync();
    Task<ContatoDTO> GetByIdAsync(int id);
    Task AddAsync(ContatoDTO contatoDto);
    Task UpdateAsync(int id, ContatoDTO contatoDto);
    Task DeleteAsync(int id);
}