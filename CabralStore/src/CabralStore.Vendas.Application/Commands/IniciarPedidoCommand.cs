using System;
using FluentValidation;
using CabralStore.Core.Messages;

namespace CabralStore.Vendas.Application.Commands
{
    public class IniciarPedidoCommand : Command
    {
        public Guid PedidoId { get; private set; }
        public Guid ClienteId { get; private set; }
        public decimal Total { get; private set; }
        public string NomeCartao { get; private set; }
        public string NumeroCartao { get; private set; }
        public string ExpiracaoCartao { get; private set; }
        public string CvvCartao { get; private set; }

        public IniciarPedidoCommand(Guid pedidoId, Guid clienteId, decimal total)
        {
            PedidoId = pedidoId;
            ClienteId = clienteId;
            Total = total;
            NomeCartao = "NuBank";
            NumeroCartao = "5184512040861701";
            ExpiracaoCartao = "04/11/2021";
            CvvCartao = "182";
        }

        public override bool EhValido()
        {
            ValidationResult = new IniciarPedidoValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class IniciarPedidoValidation : AbstractValidator<IniciarPedidoCommand>
    {
        public IniciarPedidoValidation()
        {
            RuleFor(c => c.ClienteId)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do cliente inválido");

            RuleFor(c => c.PedidoId)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do pedido inválido");

            //RuleFor(c => c.NomeCartao)
            //    .NotEmpty()
            //    .WithMessage("O nome no cartão não foi informado");

            //RuleFor(c => c.NumeroCartao)
            //    .CreditCard()
            //    .WithMessage("Número de cartão de crédito inválido");

            //RuleFor(c => c.ExpiracaoCartao)
            //    .NotEmpty()
            //    .WithMessage("Data de expiração não informada");

            //RuleFor(c => c.CvvCartao)
            //    .Length(3, 4)
            //    .WithMessage("O CVV não foi preenchido corretamente");
        }
    }
}