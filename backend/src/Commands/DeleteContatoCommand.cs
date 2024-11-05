using MediatR;

public class DeleteContatoCommand : IRequest<bool>
{
    public int Id { get; set; }
}