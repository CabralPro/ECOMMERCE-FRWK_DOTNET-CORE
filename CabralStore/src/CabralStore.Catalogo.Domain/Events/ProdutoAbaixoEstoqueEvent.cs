﻿using CabralStore.Core.Messages.CommonMessages.DomainEvents;
using System;

namespace CabralStore.Catalogo.Domain.Events
{
    public class ProdutoAbaixoEstoqueEvent : DomainEvent
    {
        public int QuantidadeRestante { get; private set; }

        public ProdutoAbaixoEstoqueEvent(Guid aggregateId, int quantidadeRestante) 
            : base(aggregateId)
        {
            QuantidadeRestante = quantidadeRestante;
        }

    }
}
