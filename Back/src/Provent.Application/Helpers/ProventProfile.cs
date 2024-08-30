using AutoMapper;
using Provent.Application.Dtos;
using Provent.Domain;

namespace Provent.API.Helpers
{
    public class ProventProfile : Profile
    {
        public ProventProfile()
        {
            CreateMap<Batch, BatchDto>().ReverseMap();
            CreateMap<Event, EventDto>().ReverseMap();
            CreateMap<SocialNetwork, SocialNetworkDto>().ReverseMap();
            CreateMap<Speaker, SpeakerDto>().ReverseMap();
        }
    }
}