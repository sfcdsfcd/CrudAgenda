using MediatR;

public class GetContatoByIdQuery : IRequest<ContatoDTO>
{
    public int Id { get; set; }
}