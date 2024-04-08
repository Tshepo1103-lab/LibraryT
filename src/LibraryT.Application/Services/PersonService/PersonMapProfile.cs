using AutoMapper;
using LibraryT.Authorization.Users;
using LibraryT.Domain;
using LibraryT.Services.PersonService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryT.Services.PersonService
{
    public class PersonMapProfile : Profile
    {
        public PersonMapProfile()
        {
            CreateMap<PersonDto, Person>()
            .ForMember(e => e.Id, d => d.Ignore());

            CreateMap<PersonDto, User>()
                .ForMember(x => x.Name, m => m.MapFrom(x => x.Name))
                .ForMember(x => x.PhoneNumber, m => m.MapFrom(x => x.PhoneNumber))
                .ForMember(x => x.EmailAddress, m => m.MapFrom(x => x.EmailAddress))
                .ForMember(x => x.Password, m => m.MapFrom(x => x.Password))
                .ForMember(x => x.Surname, m => m.MapFrom(x => x.Surname))
                .ForMember(x => x.Roles, m => m.MapFrom(x => x.RoleNames))
                .ForMember(x => x.UserName, m => m.MapFrom(x => x.Name + x.Surname.Substring(0, 4)));



            CreateMap<PersonDto, User>()
            .ForMember(e => e.Id, d => d.Ignore());

        }
    }
}
