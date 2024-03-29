﻿using AutoMapper;
using CR.Panenado.API.Models;
using CR.Panenado.EF.Entities;

namespace CR.Panenado.API.Profiles
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles() { 
            //CreateMap<Producto, ProductoModel.CatalogoDisponible>()
            //    .ForMember(dest => dest.TipoProducto, source => source.MapFrom(s => s.IdTipoProductoNavigation.Nombre))
            //    .ForMember(dest => dest.ValorVenta, source => source.MapFrom(s => s.ProductoPrecios.Where(x=>x.Activo).Single().ValorVenta));

            //CreateMap<Pedido, PedidoModel>()
            //    .ForMember(dest => dest.Items, source => source.MapFrom(s => s.PedidoDetalles))
            //    .ForMember(dest => dest.Fechas, source => source.MapFrom(s => s.PedidoFechas));
            //CreateMap<PedidoModel, Pedido>()
            //    .ForMember(dest => dest.PedidoDetalles, source => source.MapFrom(s => s.Items))
            //    .ForMember(dest => dest.PedidoFechas, source => source.MapFrom(s => s.Fechas));
            
            CreateMap<PedidoDetalleModel, PedidoDetalle>();
            CreateMap<PedidoDetalle, PedidoDetalleModel>();

            //CreateMap<PedidoFechaModel.Entidad, PedidoFecha>();
            //CreateMap<PedidoFecha, PedidoFechaModel.Entidad>();

            CreateMap<ProductoModel, Producto>();
            CreateMap<Producto, ProductoModel>();

            CreateMap<ClienteModel, Cliente>();
            CreateMap<Cliente, ClienteModel>();
        }
    }
}
