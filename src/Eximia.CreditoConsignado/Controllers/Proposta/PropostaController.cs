using AutoMapper;
using Eximia.CreditoConsignado.Application.CreateProposta;
using Eximia.CreditoConsignado.Controllers.Proposta.CreateProposta;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Eximia.CreditoConsignado.Controllers.Proposta
{
    [ApiController]
    [Route("api/[controller]")]
    public class PropostaController(IMediator _mediator, IMapper _mapper) : Controller
    {
        [HttpPost]
        public async Task<IActionResult> CreateProposta([FromBody] CreatePropostaRequest request, CancellationToken cancellationToken)
        {
            var validator = new CreatePropostaRequestValidator();
            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)            
                return BadRequest(validationResult.Errors);            

            var command = _mapper.Map<CreatePropostaCommand>(request);
            var response = await _mediator.Send(command, cancellationToken);

            return Created(
                String.Empty,
                new
                {
                    Message = "Proposta criada com sucesso",
                    ID = response.Id
                });
        }
    }
}
