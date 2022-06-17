using AutoMapper;
using ITICDE.Models;
using ITICDE.ViewModels;
using System.Net.Mail;

namespace ITICDE.AutoMapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserViewModel>()
                   .ForMember(dest => dest.Name,

         opt => opt.MapFrom(src => src.Name))
                   .ForMember(dest => dest.Email,

         opt => opt.MapFrom(src => src.Email))
                   .ForMember(dest => dest.Discipline,
         
         opt => opt.MapFrom(src => src.Discipline))
                   .ForMember(dest => dest.OrganizationType,

         opt => opt.MapFrom(src => src.OrganizationType));

         CreateMap<UserViewModel, User>()
                    .ForMember(dest => dest.Name,

          opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.Email,

          opt => opt.MapFrom(src => src.Email))
                    .ForMember(dest => dest.UserName,

          opt => opt.MapFrom(src => new MailAddress(src.Email).User ))
                    .ForMember(dest => dest.Discipline,

          opt => opt.MapFrom(src => src.Discipline))
                    .ForMember(dest => dest.OrganizationType,

          opt => opt.MapFrom(src => src.OrganizationType));

        }
    }
}
