using AutoMapper;
using CR.Panenado.API.Models;
using CR.Panenado.EF.Entities;

namespace CR.Panenado.API.Profiles
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles() { 
            CreateMap<Producto, ProductoModel.CatalogoDisponible>()
                .ForMember(dest => dest.TipoProducto, source => source.MapFrom(s => s.IdTipoProductoNavigation.Nombre))
                .ForMember(dest => dest.ValorVenta, source => source.MapFrom(s => s.ProductoPrecios.Where(x=>x.Activo).Single().ValorVenta));
        }
    }
}
