using Microsoft.Extensions.DependencyInjection;
using NerdStore.Catalogo.Application.Interfaces.Services;
using NerdStore.Catalogo.Application.Services;
using NerdStore.Catalogo.Data.Contexts;
using NerdStore.Catalogo.Data.Repository;
using NerdStore.Catalogo.Domain.Interfaces;
using NerdStore.Catalogo.Domain.Services;
using NerdStore.Core.Bus;

namespace NerdStore.WebApp.MVC.Setup
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services )
        {
            services.AddScoped<IMediatrHandler, MediatrHandler>();

            // Catalogo
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IEstoqueService, EstoqueService>();
            services.AddScoped<CatalogoContext>();
        }
    }
}
