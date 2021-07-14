using NerdStore.Core.DomainObjects;
using System;

namespace NerdStore.Catalogo.Domain.Events
{
    public class ProdutoEstoqueBaixoEvent : DomainEvent
    {
        public int QuantidadeEstoqueRestante { get; private set; }

        public ProdutoEstoqueBaixoEvent(Guid aggredateId, int quantidadeEstoqueRestante) : base(aggredateId)
        {
            QuantidadeEstoqueRestante = quantidadeEstoqueRestante;
        }
    }
}
