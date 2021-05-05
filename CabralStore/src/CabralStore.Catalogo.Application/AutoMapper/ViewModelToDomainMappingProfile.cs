using AutoMapper;
using CabralStore.Catalogo.Application.ViewModels;
using CabralStore.Catalogo.Domain;

namespace CabralStore.Catalogo.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ProdutoViewModel, Produto>();
        }
    }
}