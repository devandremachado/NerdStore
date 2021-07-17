using AutoMapper;
using NerdStore.Modulo.Catalogo.Application.DTO;
using NerdStore.Modulo.Catalogo.Domain.Entites;

namespace NerdStore.Modulo.Catalogo.Application.AutoMapper
{
    public class DomainToDtoMappingProfile : Profile
    {
        public DomainToDtoMappingProfile()
        {
            CreateMap<Produto, ProdutoDTO>()
                    .ForMember(p => p.Largura, o => o.MapFrom(s => s.Dimensoes.Largura))
                    .ForMember(p => p.Altura, o => o.MapFrom(s => s.Dimensoes.Altura))
                    .ForMember(p => p.Profundidade, o => o.MapFrom(s => s.Dimensoes.Profundidade));

            CreateMap<Categoria, CategoriaDTO>();
        }
    }
}
