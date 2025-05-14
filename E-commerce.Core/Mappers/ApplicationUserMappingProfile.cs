using AutoMapper;
using E_commerce.Core.DTO;
using E_commerce.Core.Entities;

namespace E_commerce.Core.Mappers
{
    public class ApplicationUserMappingProfile : Profile
    {
        public ApplicationUserMappingProfile()
        {
            CreateMap<ApplicationUser, AuthResponse>()
                .ForMember(dist => dist.succes, opt => opt.Ignore())
                .ForMember(dist => dist.Token, opt => opt.Ignore());
        }
    }
}
