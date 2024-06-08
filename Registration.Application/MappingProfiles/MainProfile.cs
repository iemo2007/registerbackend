using AutoMapper;
using Registration.Application.DTOs;
using Registration.Application.Features.AccountFeatures.Commands.CreateAccount;
using Registration.Application.Features.GovernateFeatures.Queries.GetGovernatesWithCities;
using Registration.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Application.MappingProfiles
{
    public class MainProfile: Profile
    {
        public MainProfile()
        {
            CreateMap<City, CityDTO>().ReverseMap();
            CreateMap<Governate, GetGovernatesWithCitiesDTO>().ReverseMap();
            CreateMap<CreateAccountCommandAddressDTO, Address>().ReverseMap();
            CreateMap<CreateAccountCommandDTO, Account>().ReverseMap();
        }
    }
}
