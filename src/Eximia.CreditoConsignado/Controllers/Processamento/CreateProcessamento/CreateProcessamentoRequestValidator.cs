using FluentValidation;

namespace Eximia.CreditoConsignado.Controllers.Processamento.CreateProcessamento
{
    public class CreateProcessamentoRequestValidator : AbstractValidator<CreateProcessamentoRequest>
    {
        public CreateProcessamentoRequestValidator()
        {
            RuleFor(x => x.PropostaId).NotEmpty().WithMessage("PropostaId é obrigatório");
        }
    }
}
