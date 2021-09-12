using NerdStore.Shared.Data;
using NerdStore.Vendas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdStore.Vendas.Domain.Interfaces
{
    public interface IPedidoRepository : IRepository<Pedido>
    {
        Task<Pedido> ObterPorId(Guid id);
        Task<IEnumerable<Pedido>> ObterListaPorClienteId(Guid clienteId);
        Task<Pedido> ObterPedidoRascunhoPorClienteId (Guid clienteId);
        void Adicionar(Pedido pedido);
        void Atualizar(Pedido pedido);

        Task<PedidoItem> ObterItemPorId(Guid id);
        Task<PedidoItem> ObterItemPorPedido(Guid pedidoId, Guid produtoId);
        void AdicionarItem(PedidoItem item);
        void AtualizarItem(PedidoItem item);
        void RemoverItem(PedidoItem item);

        Task<Voucher> ObterVoucherPorId(string codigo);
    }
}
