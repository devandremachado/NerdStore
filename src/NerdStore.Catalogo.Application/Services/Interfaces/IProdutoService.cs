using NerdStore.Modulo.Catalogo.Application.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NerdStore.Modulo.Catalogo.Application.Interfaces.Services
{
    public interface IProdutoService : IDisposable
    {
        Task<IEnumerable<ProdutoDTO>> ObterPorCategoria(int codigo);
        Task<ProdutoDTO> ObterPorId(Guid codigo);
        Task<IEnumerable<ProdutoDTO>> ObterTodos();
        Task<IEnumerable<CategoriaDTO>> ObterCategorias();

        Task AdicionarProduto(ProdutoDTO produtoDto);
        Task AtualizarProduto(ProdutoDTO produtoDto);

        Task<ProdutoDTO> DebitarEstoque(Guid id, int quantidade);
        Task<ProdutoDTO> ReporEstoque(Guid id, int quantidade);


    }
}
