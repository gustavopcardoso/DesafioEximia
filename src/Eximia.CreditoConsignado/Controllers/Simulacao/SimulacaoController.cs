using AutoMapper;
using Eximia.CreditoConsignado.Application.CreateSimulacao;
using Eximia.CreditoConsignado.Controllers.Simulacao.CreateSimulacao;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Eximia.CreditoConsignado.Controllers.Simulacao
{
    [ApiController]
    [Route("api/[controller]")]
    public class SimulacaoController(IMediator _mediator, IMapper _mapper) : Controller
    {
        [HttpPost]
        public async Task<IActionResult> CreateSimulacao([FromBody] CreateSimulacaoRequest request, CancellationToken cancellationToken)
        {
            var validator = new CreateSimulacaoRequestValidator();
            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<CreateSimulacaoCommand>(request);
            var response = await _mediator.Send(command, cancellationToken);

            return Created(
                String.Empty,
                new
                {
                    Message = "Simulação gerada com sucesso",
                    response.Valor,
                    response.Parcelas,
                    response.ValorFinal
                });
        }
    }
}
