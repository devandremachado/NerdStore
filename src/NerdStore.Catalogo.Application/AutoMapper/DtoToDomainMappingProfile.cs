using AutoMapper;
using NerdStore.Catalogo.Application.DTO;
using NerdStore.Catalogo.Domain.Entities;
using NerdStore.Modulo.Catalogo.Domain.ValueObjects;

namespace NerdStore.Catalogo.Application.AutoMapper
{
    public class DtoToDomainMappingProfile : Profile
    {
        public DtoToDomainMappingProfile()
        {
            CreateMap<CategoriaDTO, Categoria>()
                .ConstructUsing(c => new Categoria(c.Nome, c.Codigo));

            CreateMap<ProdutoDTO, Produto>()
                .ConstructUsing(p => new Produto(p.Nome, p.Descricao, p.Ativo, p.Valor, p.CategoriaId, p.DataCadastro, p.Imagem, p.QuantidadeEstoque, new DimensaoVO(p.Altura, p.Largura, p.Profundidade)));
        }
    }
}
