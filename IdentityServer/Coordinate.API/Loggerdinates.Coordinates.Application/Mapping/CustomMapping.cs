using AutoMapper;
using Loggerdinates.Coordinates.Application.Dtos;
using Loggerdinates.Coortinates.Domain.CoordinateAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loggerdinates.Coordinates.Application.Mapping
{
    internal class CustomMapping : Profile
    {
        public CustomMapping()
        {
            CreateMap<Coordinate,CoordinateDto>().ReverseMap();
            CreateMap<CoordinateInformation,CoordinateInformationDto>().ReverseMap();
        }
    }
}
