using NerdStore.Shared.DomainObjects;
using System;

namespace NerdStore.Vendas.Domain.Entities
{
    public class PedidoItem : Entity
    {
        public PedidoItem(Guid produtoId, string nomeProduto, int quantidade, decimal valorUnitario)
        {
            ProdutoId = produtoId;
            NomeProduto = nomeProduto;
            Quantidade = quantidade;
            ValorUnitario = valorUnitario;
        }

        // EF
        protected PedidoItem() { }

        public Guid PedidoId { get; private set; }
        public Guid ProdutoId { get; private set; }
        public string NomeProduto { get; private set; }
        public int Quantidade { get; private set; }
        public decimal ValorUnitario { get; private set; }

        // EF Relation
        public Pedido Pedido { get; set; }

        internal void AssociarPedido(Guid pedidoId)
        {
            PedidoId = pedidoId;
        }

        public decimal CalcularValor()
        {
            return Quantidade * ValorUnitario;
        }

        internal void AdicionarUnidades(int unidades)
        {
            Quantidade += unidades;
        }

        internal void AtualizarUnidades(int unidades)
        {
            Quantidade = unidades;
        }

        public override bool EhValido()
        {
            return true;
        }
    }
}
