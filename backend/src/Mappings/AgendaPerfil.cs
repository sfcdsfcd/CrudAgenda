using AutoMapper;

public class AgendaPerfil : Profile
{
    public AgendaPerfil()
    {
        CreateMap<Contato, ContatoDTO>().ReverseMap();
        CreateMap<CreateContatoCommand, Contato>();

    }
}