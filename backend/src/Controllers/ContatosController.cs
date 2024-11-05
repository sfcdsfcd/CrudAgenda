using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class ContatosController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IValidator<CreateContatoCommand> _createValidator;
    private readonly IValidator<UpdateContatoCommand> _updateValidator;

    public ContatosController(IMediator mediator, IValidator<CreateContatoCommand> createValidator, IValidator<UpdateContatoCommand> updateValidator)
    {
        _mediator = mediator;
        _createValidator = createValidator;
        _updateValidator = updateValidator;
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateContatoCommand command)
    {
        var validationResult = await _createValidator.ValidateAsync(command);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id }, command);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateContatoCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest("ID da query string não é o id do request");
        }

        var validationResult = await _updateValidator.ValidateAsync(command);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        var result = await _mediator.Send(command);
        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteContatoCommand { Id = id };
        var result = await _mediator.Send(command);
        if (!result)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var query = new GetContatoByIdQuery { Id = id };
        var contato = await _mediator.Send(query);
        if (contato == null)
        {
            return NotFound();
        }
        return Ok(contato);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetAllContatosQuery();
        var contatos = await _mediator.Send(query);
        return Ok(contatos);
    }
}