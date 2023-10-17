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

        foreach (int numberId in masiveCallCreationDTO.IdsNumbersToCall)
        {
            Call call = new Call
            {
                NumberId = numberId,
                AudioId = masiveCallCreationDTO.AudioId,
            };
            calls.Add(call);
        }
        ICollection<Call> callsCollect = calls;
        return callsCollect;
    }
}