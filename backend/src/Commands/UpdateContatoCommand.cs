using MediatR;

public class UpdateContatoCommand : IRequest<bool>
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
}