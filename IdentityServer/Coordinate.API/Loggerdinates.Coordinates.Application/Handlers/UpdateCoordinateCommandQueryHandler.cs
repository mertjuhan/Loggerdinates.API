using AutoMapper;
using Loggerdinates.Coordinates.Application.Commands;
using Loggerdinates.Coordinates.Application.Dtos;
using Loggerdinates.Coordinates.Application.Mapping;
using Loggerdinates.Coordinates.Infrastructure.Persistence;
using Loggerdinates.Coortinates.Domain.CoordinateAggregate;
using Loggerdinates.Shared.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loggerdinates.Coordinates.Application.Handlers
{
    public class UpdateCoordinateCommandQueryHandler : IRequestHandler<UpdateCoordinateCommandQuery, Response<CoordinateDto>>
    {
        private readonly CoordinateDbContext _context;

        public UpdateCoordinateCommandQueryHandler(CoordinateDbContext context)
        {
            _context = context;
        }

        public async Task<Response<CoordinateDto>> Handle(UpdateCoordinateCommandQuery request, CancellationToken cancellationToken)
        {
            var coordinateItem = await _context.Coordinates.Where(x => x.Id == request.Id).FirstOrDefaultAsync();

            if (coordinateItem == null)
            {
               return Response<CoordinateDto>.Fail("This coordinate does not exist in database", 400);
            }

            coordinateItem.CoordinateInformation = ObjectMapper.Mapper.Map<CoordinateInformation>(request.CoordinateInformation);
            await _context.SaveChangesAsync();

            return Response<CoordinateDto>.Success(new CoordinateDto { CoordinateInformation = request.CoordinateInformation, CreatedBy = request.CreatedBy }, 200);
        }
    }
}
