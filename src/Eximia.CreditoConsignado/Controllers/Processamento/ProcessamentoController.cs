using AutoMapper;
using Eximia.CreditoConsignado.Application.CreateProcessamento;
using Eximia.CreditoConsignado.Controllers.Processamento.CreateProcessamento;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Eximia.CreditoConsignado.Controllers.Processamento
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProcessamentoController(IMediator _mediator, IMapper _mapper) : Controller
    {
        [HttpPost]
        public async Task<IActionResult> CreateProcessamento([FromBody] CreateProcessamentoRequest request, CancellationToken cancellationToken)
        {
            var validator = new CreateProcessamentoRequestValidator();
            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<CreateProcessamentoCommand>(request);
            var response = await _mediator.Send(command, cancellationToken);

            if (!response.Sucesso)
                return BadRequest("Proposta não encontrada ou não está em análise.");

            return Created(
                String.Empty,
                new
                {
                    Message = "Processamento iniciado com sucesso.",
                    request.PropostaId
                });
        }
    }
}
