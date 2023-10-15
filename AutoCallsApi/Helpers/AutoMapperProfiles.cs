using AutoCallsApi.DTOs;
using AutoCallsApi.Models;
using AutoMapper;

namespace AutoCallsApi.Helpers;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<NumberCreationDTO, Number>();
        CreateMap<MasiveCallCreationDTO, MasiveCall>()
            .ForMember(
                dest => dest.Calls,
                opt => opt.MapFrom(src => MapCalls(src))
            );
    }

    private ICollection<Call> MapCalls(MasiveCallCreationDTO masiveCallCreationDTO)
    {
        var calls = new List<Call>();

        foreach (Number number in masiveCallCreationDTO.NumbersToCall)
        {
            Call call = new Call
            {
                NumberId = number.Id,
                Number = number,
                AudioId = masiveCallCreationDTO.AudioId,
            };
            calls.Add(call);
        }
        ICollection<Call> callsCollect = calls;
        return callsCollect;
    }
}