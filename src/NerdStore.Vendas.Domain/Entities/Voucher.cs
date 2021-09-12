using NerdStore.Shared.DomainObjects;
using NerdStore.Vendas.Domain.Enums;
using System;
using System.Collections.Generic;

namespace NerdStore.Vendas.Domain.Entities
{
    public class Voucher : Entity
    {
        // EF
        protected Voucher() { }

        public string Codigo { get; private set; }
        public decimal? Percentual { get; private set; }
        public decimal? ValorDesconto { get; private set; }
        public int Quantidade { get; private set; }
        public ETipoDesconto TipoDesconto { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public DateTime DataUtilizacao { get; private set; }
        public DateTime DataValidade { get; private set; }
        public bool Ativo { get; private set; }
        public bool Utilizado { get; private set; }

        // EF Relation
        public ICollection<Pedido> Pedidos { get; set; }
    }
}
