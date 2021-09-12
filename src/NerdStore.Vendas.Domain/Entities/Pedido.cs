using NerdStore.Shared.DomainObjects;
using NerdStore.Vendas.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NerdStore.Vendas.Domain.Entities
{
    public class Pedido : Entity, IAggregateRoot
    {

        public Pedido(Guid clienteId, bool voucherUtilizado, decimal desconto, decimal valorTotal)
        {
            ClienteId = clienteId;
            VoucherUtilizado = voucherUtilizado;
            Desconto = desconto;
            ValorTotal = valorTotal;

            _pedidoItems = new List<PedidoItem>();
        }

        // EF
        protected Pedido()
        {
            _pedidoItems = new List<PedidoItem>();
        }

        public int Codigo { get; private set; }
        public Guid ClienteId { get; private set; }
        public Guid? VoucherId { get; private set; }
        public bool VoucherUtilizado { get; private set; }
        public decimal Desconto { get; private set; }
        public decimal ValorTotal { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public EPedidoStatus PedidoStatus { get; private set; }

        private readonly List<PedidoItem> _pedidoItems;
        public IReadOnlyCollection<PedidoItem> PedidoItems => _pedidoItems;

        // EF Relation
        public Voucher Voucher { get; set; }

        public void CalcularValorTotalDesconto()
        {
            if (VoucherUtilizado == false) return;

            decimal desconto = 0;
            var valor = ValorTotal;

            if (Voucher.TipoDesconto == ETipoDesconto.Porcentagem)
            {
                if (Voucher.Percentual.HasValue)
                {
                    desconto = (valor * Voucher.Percentual.Value) / 100;
                    valor -= desconto;
                }
            }
            else
            {
                if (Voucher.ValorDesconto.HasValue)
                {
                    desconto = Voucher.ValorDesconto.Value;
                    valor -= desconto;
                }
            }

            ValorTotal = valor < 0 ? 0 : valor;
            Desconto = desconto;
        }

        public void CalcularValorPedido()
        {
            ValorTotal = PedidoItems.Sum(p => p.CalcularValor());
            CalcularValorTotalDesconto();
        }

        public void AplicarVoucher(Voucher voucher)
        {
            Voucher = voucher;
            VoucherUtilizado = true;
            CalcularValorPedido();
        }

        public bool PedidoItemExistente(PedidoItem item)
        {
            return _pedidoItems.Any(p => p.ProdutoId == item.ProdutoId);
        }

        public void AdicionarItem(PedidoItem item)
        {
            if (item.EhValido() == false) return;

            item.AssociarPedido(Id);

            if (PedidoItemExistente(item) == true)
            {
                var itemExistente = _pedidoItems.FirstOrDefault(p => p.ProdutoId == item.ProdutoId);
                itemExistente.AdicionarUnidades(item.Quantidade);
                item = itemExistente;

                _pedidoItems.Remove(itemExistente);
            }

            item.CalcularValor();
            _pedidoItems.Add(item);

            CalcularValorPedido();
        }

        public void RemoverItem(PedidoItem item)
        {
            var itemExistente = _pedidoItems.FirstOrDefault(p => p.ProdutoId == item.ProdutoId);

            if (itemExistente == null) throw new DomainException($"O item {item.NomeProduto} não pertence ao pedido");
            _pedidoItems.Remove(item);

            CalcularValorPedido();
        }

        public void AtualizarItem(PedidoItem item)
        {
            if (item.EhValido() == false) return;

            item.AssociarPedido(Id);

            var itemExistente = _pedidoItems.FirstOrDefault(p => p.ProdutoId == item.ProdutoId);

            if (itemExistente == null) throw new DomainException($"O item {item.NomeProduto} não pertence ao pedido");

            _pedidoItems.Remove(itemExistente);
            _pedidoItems.Add(item);

            CalcularValorPedido();
        }

        public void AtualizarUnidades(PedidoItem item, int unidades)
        {
            item.AtualizarUnidades(unidades);
            AtualizarItem(item);
        }

        public void TornarRascunho()
        {
            PedidoStatus = EPedidoStatus.Rascunho;
        }

        public void IniciarPedido()
        {
            PedidoStatus = EPedidoStatus.Iniciado;
        }

        public void FinalizarPedido()
        {
            PedidoStatus = EPedidoStatus.Pago;
        }

        public void CalcelarPedido()
        {
            PedidoStatus = EPedidoStatus.Cancelado;
        }

        public static class PedidoFactory
        {
            public static Pedido NovoPedidoRascunho(Guid clienteId)
            {
                var pedido =  new Pedido
                {
                    ClienteId = clienteId
                };

                pedido.TornarRascunho();
                return pedido;
            }
        }
    }
}
