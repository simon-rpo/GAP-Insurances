using AutoMapper;
using Insurances.Dto;
using Insurances.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurances.Middleware
{
    public static class AutoMapperConfig
    {
        public static void Configure()
        {

            Mapper.Initialize(
                config =>
                {
                    config.CreateMap<Policy, PolicyDto>().ReverseMap();
                    config.CreateMap<Client, ClientDto>().ReverseMap();
                });
        }
    }
}