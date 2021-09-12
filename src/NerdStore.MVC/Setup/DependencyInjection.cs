using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NerdStore.Modulo.Catalogo.Application.Interfaces.Services;
using NerdStore.Modulo.Catalogo.Application.Services;
using NerdStore.Modulo.Catalogo.Data.Contexts;
using NerdStore.Modulo.Catalogo.Data.Repository;
using NerdStore.Modulo.Catalogo.Domain.Events;
using NerdStore.Modulo.Catalogo.Domain.Interfaces;
using NerdStore.Modulo.Catalogo.Domain.Services;
using NerdStore.Shared.Bus;
using NerdStore.Vendas.Application.Commands;
using NerdStore.Vendas.Application.Commands.Handlers;
using NerdStore.Vendas.Data.Contexts;
using NerdStore.Vendas.Data.Repository;
using NerdStore.Vendas.Domain.Interfaces;

namespace NerdStore.MVC.Setup
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            // Mediator
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            // Catalogo
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IProdutoAppService, ProdutoAppService>();
            services.AddScoped<IEstoqueService, EstoqueService>();
            services.AddScoped<CatalogoContext>();

            services.AddScoped<INotificationHandler<ProdutoEstoqueBaixoEvent>, ProdutoEventHandler>();


            // Vendas
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<VendasContext>();

            services.AddScoped<IRequestHandler<AdicionarItemPedidoCommand, bool>, PedidoCommandHandler>();

        }
    }
}
