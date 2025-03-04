using FluentValidation;

namespace Eximia.CreditoConsignado.Controllers.Proposta.CreateProposta
{
    public class CreatePropostaRequestValidator : AbstractValidator<CreatePropostaRequest>
    {
        public CreatePropostaRequestValidator() 
        {
            RuleFor(x => x.AgenteId).NotEmpty().WithMessage("AgenteId é obrigatório");
            RuleFor(x => x.CPF).NotEmpty().WithMessage("CPF é obrigatório");
            RuleFor(x => x.Nome).NotEmpty().WithMessage("Nome é obrigatório");
            RuleFor(x => x.DataNascimento).NotEmpty().WithMessage("Data de nascimento é obrigatória");
            RuleFor(x => x.DadosRendimento).SetValidator(new DadosRendimentoValidator());
            RuleFor(x => x.Endereco).SetValidator(new EnderecoValidator());
            RuleFor(x => x.Contato).SetValidator(new ContatoValidator());
        }       
    }

    public class DadosRendimentoValidator : AbstractValidator<DadosRendimentoRequest>
    {
        public DadosRendimentoValidator()
        {
            RuleFor(x => x.NumeroINSS).NotEmpty().WithMessage("Número INSS é obrigatório");
            RuleFor(x => x.ValorAposentadoria).GreaterThan(0).WithMessage("Valor da aposentadoria deve ser maior que zero");
        }
    }

    public class EnderecoValidator : AbstractValidator<EnderecoRequest>
    {
        public EnderecoValidator()
        {
            RuleFor(x => x.CEP).NotEmpty().WithMessage("CEP é obrigatório");
            RuleFor(x => x.Logradouro).NotEmpty().WithMessage("Logradouro é obrigatório");
            RuleFor(x => x.Numero).NotEmpty().WithMessage("Número é obrigatório");
            RuleFor(x => x.Bairro).NotEmpty().WithMessage("Bairro é obrigatório");
            RuleFor(x => x.Cidade).NotEmpty().WithMessage("Cidade é obrigatório");
            RuleFor(x => x.Estado).NotEmpty().WithMessage("Estado é obrigatório");
        }
    }

    public class ContatoValidator : AbstractValidator<ContatoRequest>
    {
        public ContatoValidator()
        {
            RuleFor(x => x.Telefone).NotEmpty().WithMessage("Telefone é obrigatório");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email é obrigatório");
        }
    }
}
