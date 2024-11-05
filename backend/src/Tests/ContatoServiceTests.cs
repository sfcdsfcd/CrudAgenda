using AutoMapper;
using Xunit;
using Moq;

public class ContatoServiceTests
{
    private readonly IContatoService _contatoService;
    private readonly Mock<IContatoRepository> _contatoRepositoryMock;
    private readonly IMapper _mapper;

    public ContatoServiceTests()
    {
        _contatoRepositoryMock = new Mock<IContatoRepository>();
        var config = new MapperConfiguration(cfg => cfg.AddProfile<AgendaPerfil>());
        _mapper = config.CreateMapper();
        _contatoService = new ContatoService(_contatoRepositoryMock.Object, _mapper);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnAllContatos()
    {
        var contatos = new List<Contato>
        {
            new() { Id = 1, Nome = "John Doe", Email = "john@example.com", Telefone = "123456789" },
            new() { Id = 2, Nome = "Jane Doe", Email = "jane@example.com", Telefone = "987654321" }
        };
        _contatoRepositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(contatos);

        var result = await _contatoService.GetAllAsync();

        Assert.Equal(2, result.Count());
    }

}