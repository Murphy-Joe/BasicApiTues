using AutoMapper;
using BasicApi.Controllers;
using BasicApi.Data;

namespace BasicApi.AutomapperProfiles;

public class AgentsProfile : Profile
{
    public AgentsProfile()
    {
        // (Agent => AgentResponseItem)
       CreateMap<Agent, AgentResponseItem>();
        CreateMap<AgentCreateRequest, Agent>()
            .ForMember(dest => dest.State, options => options.MapFrom(src => src.StateCode))
            .ForMember(dest => dest.Retired, options => options.MapFrom(_ => false))
            .ForMember(dest => dest.Added, options => options.MapFrom(_ => DateTime.Now));
    }
}
