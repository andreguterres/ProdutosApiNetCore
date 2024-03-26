using AutoMapper;
using ProdutosApiNetCore.Dto;
using ProdutosApiNetCore.Entity;

namespace ProdutosApiNetCore.Mappings
{
    public class EntitiesToDtoMapping: Profile
    {
        public EntitiesToDtoMapping ()
        {
            CreateMap<Pedido,PedidoDto>().ReverseMap();
            CreateMap<Item, ItemDto>().ReverseMap();
            CreateMap<Pedido, EditarPedidoDto>().ReverseMap();
            CreateMap<Item, EditarItemDto>().ReverseMap();



        }
    }
}
