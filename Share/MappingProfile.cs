using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets.Domains;

namespace Share
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
          CreateMap<User,UserDto>().ReverseMap();
        }
    }
}
