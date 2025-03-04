using Eximia.CreditoConsignado.Domain.Exceptions;

namespace Eximia.CreditoConsignado.Domain.Entities
{
    public class Simulacao
    {
        public Guid Id { get; set; }
        public Guid PropostaId { get; set; }
        public decimal Valor { get; set; }
        public int Parcelas { get; set; }
        public decimal ValorFinal { get; set; }

        public Simulacao()
        {
            Id = Guid.NewGuid();
        }

        public void ValidarParcelamentoMaximo()
        {
            if (Parcelas > 60)            
                throw new DomainException("O parcelamento máximo é de 60 meses.");            
        }

        public void ValidarValorParcelaMaximo(decimal rendimentoProponente)
        {
            decimal valorParcela = Valor / Parcelas;
            var percentualRendimento = valorParcela / rendimentoProponente;

            if (percentualRendimento > 0.3m)            
                throw new DomainException("O valor da parcela não pode ser superior a 30% do rendimento do proponente.");            
        }
        
        public decimal CalcularValorFinal(decimal valorProposto)
        {
            int totalAnos = Parcelas / 12;
            double taxaAnual = 12;

            // Precisaria calcular um juro proporcional aos meses do ultimo ano caso não sejam 12.
            decimal valorFinal = valorProposto * (decimal)Math.Pow((1 + (taxaAnual/100)), totalAnos);

            return valorFinal;
        }

        public void ValidarDataUltimaParcela(DateTime dataNascimentoProponente)
        {
            var dataUltimaParcela = DateTime.Now.AddMonths(Parcelas);
            var idadeProponente = DateTime.Now.Year - dataNascimentoProponente.Year;

            if (dataUltimaParcela.Year > DateTime.Now.Year + (80 - idadeProponente))
                throw new DomainException("A última parcela ultrapassa o limite de idade do proponente (80 anos).");
        }
    }
}
