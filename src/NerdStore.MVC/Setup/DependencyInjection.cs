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

namespace NerdStore.MVC.Setup
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IMediatrHandler, MediatrHandler>();

            // Catalogo
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IEstoqueService, EstoqueService>();
            services.AddScoped<CatalogoContext>();

            services.AddScoped<INotificationHandler<ProdutoEstoqueBaixoEvent>, ProdutoEventHandler>();
        }
    }
}
