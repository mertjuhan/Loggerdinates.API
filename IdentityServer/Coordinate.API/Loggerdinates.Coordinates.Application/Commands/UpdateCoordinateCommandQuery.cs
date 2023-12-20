using Loggerdinates.Coordinates.Application.Dtos;
using Loggerdinates.Shared.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loggerdinates.Coordinates.Application.Commands
{
    public class UpdateCoordinateCommandQuery : IRequest<Response<CoordinateDto>>
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public CoordinateInformationDto CoordinateInformation { get; set; }
    }
}
