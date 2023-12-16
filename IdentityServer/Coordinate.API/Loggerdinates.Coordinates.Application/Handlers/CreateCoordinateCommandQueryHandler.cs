using Loggerdinates.Coordinates.Application.Commands;
using Loggerdinates.Coordinates.Application.Dtos;
using Loggerdinates.Coordinates.Infrastructure.Persistence;
using Loggerdinates.Coortinates.Domain.CoordinateAggregate;
using Loggerdinates.Shared.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loggerdinates.Coordinates.Application.Handlers
{
    public class CreateCoordinateCommandQueryHandler : IRequestHandler<CreateCoordinateCommandQuery, Response<CoordinateDto>>
    {
        private readonly CoordinateDbContext _context;

        public CreateCoordinateCommandQueryHandler(CoordinateDbContext context)
        {
            _context = context;
        }

        public async Task<Response<CoordinateDto>> Handle(CreateCoordinateCommandQuery request, CancellationToken cancellationToken)
        {
            var coordinateInformation = new CoordinateInformation(request.CoordinateInformation.Name,request.CoordinateInformation.Latitude,request.CoordinateInformation.Longitude);
            var coordinateItem = new Coordinate(request.CreatedBy, coordinateInformation);

            await _context.AddAsync(coordinateItem);
            await _context.SaveChangesAsync();

            return Response<CoordinateDto>.Success(new CoordinateDto { CoordinateInformation = request.CoordinateInformation, CreatedBy = request.CreatedBy }, 200);
        }
    }
}
