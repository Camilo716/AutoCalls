using AutoCallsApi.DTOs;
using AutoCallsApi.Models;
using AutoMapper;

namespace AutoCallsApi.Helpers;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<NumberCreationDTO, Number>();
        CreateMap<MasiveCallCreationDTO, MasiveCall>();
    }
}