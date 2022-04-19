using AutoMapper;
using Bouwmarkt_DataAccess;
using Bouwmarkt_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bouwmarkt_Business.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Vestiging, VestigingDTO>().ReverseMap();      
        }
    }
}
