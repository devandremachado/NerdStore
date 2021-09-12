using AutoMapper;
using NerdStore.Modulo.Catalogo.Application.DTO;
using NerdStore.Modulo.Catalogo.Application.Interfaces.Services;
using NerdStore.Modulo.Catalogo.Domain.Entites;
using NerdStore.Modulo.Catalogo.Domain.Interfaces;
using NerdStore.Shared.DomainObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NerdStore.Modulo.Catalogo.Application.Services
{
    public class ProdutoAppService : IProdutoAppService
    {
        private readonly IEstoqueService _estoqueService;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;

        public ProdutoAppService(IEstoqueService estoqueService, IProdutoRepository produtoRepository, IMapper mapper)
        {
            _estoqueService = estoqueService;
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoriaDTO>> ObterCategorias()
        {
            return _mapper.Map<IEnumerable<CategoriaDTO>>(await _produtoRepository.ObterCategorias());
        }

        public async Task<IEnumerable<ProdutoDTO>> ObterPorCategoria(int codigo)
        {
            return _mapper.Map<IEnumerable<ProdutoDTO>>(await _produtoRepository.ObterPorCategoria(codigo));
        }

        public async Task<ProdutoDTO> ObterPorId(Guid codigo)
        {
            return _mapper.Map<ProdutoDTO>(await _produtoRepository.ObterPorId(codigo));
        }

        public async Task<IEnumerable<ProdutoDTO>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<ProdutoDTO>>(await _produtoRepository.ObterTodos());
        }

        public async Task AdicionarProduto(ProdutoDTO produtoDto)
        {
            var produto = _mapper.Map<Produto>(produtoDto);
            _produtoRepository.Adicionar(produto);

            await _produtoRepository.UnitOfWork.Commit();
        }

        public async Task AtualizarProduto(ProdutoDTO produtoDto)
        {
            var produto = _mapper.Map<Produto>(produtoDto);
            _produtoRepository.Atualizar(produto);

            await _produtoRepository.UnitOfWork.Commit();
        }

        public async Task<ProdutoDTO> DebitarEstoque(Guid id, int quantidade)
        {
            if (await _estoqueService.DebitarEstoque(id, quantidade) == false)
            {
                throw new DomainException("Falha ao debitar estoque");
            }

            return _mapper.Map<ProdutoDTO>(await _produtoRepository.ObterPorId(id));
        }

        public async Task<ProdutoDTO> ReporEstoque(Guid id, int quantidade)
        {
            if (_estoqueService.ReporEstoque(id, quantidade).Result == false)
            {
                throw new DomainException("Falha ao repor estoque");
            }

            return _mapper.Map<ProdutoDTO>(await _produtoRepository.ObterPorId(id));
        }

        public void Dispose()
        {
            _estoqueService?.Dispose();
            _produtoRepository?.Dispose();
        }
    }
}
