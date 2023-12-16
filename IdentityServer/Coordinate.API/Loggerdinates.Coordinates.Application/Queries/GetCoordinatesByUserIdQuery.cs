using Loggerdinates.Coordinates.Application.Dtos;
using Loggerdinates.Shared.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loggerdinates.Coordinates.Application.Queries
{
    public class GetCoordinatesByUserIdQuery : IRequest<Response<List<CoordinateDto>>>
    {
        public string UserId { get; set; }
    }
}
