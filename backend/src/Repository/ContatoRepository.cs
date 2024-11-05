using Microsoft.EntityFrameworkCore;

public class ContatoRepository : IContatoRepository
{
    private readonly AgendaContext _context;

    public ContatoRepository(AgendaContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Contato>> GetAllAsync()
    {
        return await _context.Contatos.ToListAsync();
    }
    public async Task DeleteAsync(Contato contato)
    {
        _context.Contatos.Remove(contato);
        await _context.SaveChangesAsync();
    }
    public async Task<Contato> GetByIdAsync(int id)
    {
        var contato = await _context.Contatos.FindAsync(id) ?? throw new KeyNotFoundException($"Contato with ID {id} not found.");
        return contato;
    }
    public async Task AddAsync(Contato contato)
    {
        await _context.Contatos.AddAsync(contato);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Contato contato)
    {
        _context.Contatos.Update(contato);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var contato = await _context.Contatos.FindAsync(id);
        if (contato != null)
        {
            _context.Contatos.Remove(contato);
            await _context.SaveChangesAsync();
        }
    }
}