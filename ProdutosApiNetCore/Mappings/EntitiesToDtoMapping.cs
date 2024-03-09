using AutoMapper;
using ProdutosApiNetCore.Dto;
using ProdutosApiNetCore.Entity;

namespace ProdutosApiNetCore.Mappings
{
    public class EntitiesToDtoMapping: Profile
    {
        public EntitiesToDtoMapping ()
        { 
            CreateMap<Pedido,AdicionarDto>().ReverseMap();
            CreateMap<Item, ItemDto>().ReverseMap();

        }
    }
}
