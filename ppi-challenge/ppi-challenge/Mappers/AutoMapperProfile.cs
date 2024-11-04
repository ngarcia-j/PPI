using AutoMapper;
using ppi_challenge.Models.DTOs;
using ppi_challenge.Models.Entities;
using ppi_challenge.Models.Requests;

namespace ppi_challenge.Mappers
{
    public class AutoMapperProfile : Profile 
    {
        public AutoMapperProfile()
        {
            CreateMap<Activo, ActivoDto>();
            CreateMap<Cuenta, CuentaDto>();
            CreateMap<Orden, OrdenDto>();
            CreateMap<OrdenDto, Orden>();
            CreateMap<NewOrdenRequest, OrdenDto>();
            CreateMap<UpdateOrdenRequest, OrdenDto>();
            CreateMap<Estado, EstadoDto>();
        }
    }
}
