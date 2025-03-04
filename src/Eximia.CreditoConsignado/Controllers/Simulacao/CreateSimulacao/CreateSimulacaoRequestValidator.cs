using FluentValidation;

namespace Eximia.CreditoConsignado.Controllers.Simulacao.CreateSimulacao
{
    public class CreateSimulacaoRequestValidator : AbstractValidator<CreateSimulacaoRequest>
    {
        public CreateSimulacaoRequestValidator()
        {
            RuleFor(x => x.PropostaId).NotEmpty().WithMessage("PropostaId é obrigatório");
            RuleFor(x => x.Valor).NotEmpty().WithMessage("Valor é obrigatório");
            RuleFor(x => x.Valor).GreaterThan(0).WithMessage("Valor deve ser maior que 0");
            RuleFor(x => x.Parcelas).NotEmpty().WithMessage("Parcelas é obrigatório");
            RuleFor(x => x.Parcelas).GreaterThan(0).WithMessage("Parcelas deve ser maior que 0");
            RuleFor(x => x.RendimentoProponente).NotEmpty().WithMessage("Rendimento do proponente é obrigatório");
            RuleFor(x => x.RendimentoProponente).GreaterThan(0).WithMessage("Rendimento do proponente deve ser maior que 0");
            RuleFor(x => x.DataNascimentoProponente).NotEmpty().WithMessage("Data de nascimento do proponente é obrigatória");
        }
    }
}
