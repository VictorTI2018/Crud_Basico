using AutoMapper;
using Crud.Domain.Dtos;
using Crud.Domain.Entities;

namespace Crud.Infra.Shared.AutoMapper
{
    public class DTOMapperProfile: Profile
    {
        public DTOMapperProfile()
        {
            CreateMap<CategoriaDadosDto, Categorias>();
            CreateMap<Categorias, CategoriaDadosDto>();

            CreateMap<LivroDadosDto, Livro>();
            CreateMap<Livro, LivroDadosDto>();
        }
    }
}
