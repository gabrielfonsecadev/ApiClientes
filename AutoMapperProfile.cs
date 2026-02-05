using AutoMapper;
using ApiClientes.Models;
using ApiClientes.Dtos;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Cliente, ClienteDto>();
        CreateMap<ClienteCreateDto, Cliente>();
    }
}
