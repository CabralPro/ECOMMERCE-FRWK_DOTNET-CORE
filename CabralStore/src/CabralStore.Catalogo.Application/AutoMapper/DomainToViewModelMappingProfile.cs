using AutoMapper;
using CabralStore.Catalogo.Application.ViewModels;
using CabralStore.Catalogo.Domain;

namespace CabralStore.Catalogo.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Produto, ProdutoViewModel>();
        }
    }
}
