using AppObraSocial.Models;
using AppObraSocial.Models.Dtos;
using AppObraSocial.Services.Clientes.Commands;
using AppObraSocial.Services.Planes.Commands;
using AutoMapper;

namespace AppObraSocial.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Cliente, ClienteDTO>().ReverseMap();
            CreateMap<Cliente, ClienteDTO>().ReverseMap();
            CreateMap<SaveClienteCommand, Cliente>().ReverseMap();
            CreateMap<SavePlanCommand, Plane>().ReverseMap();
        }
    }
}
