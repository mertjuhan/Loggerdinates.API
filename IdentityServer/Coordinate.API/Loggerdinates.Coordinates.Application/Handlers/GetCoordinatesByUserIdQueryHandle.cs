using Loggerdinates.Coordinates.Application.Dtos;
using Loggerdinates.Coordinates.Application.Mapping;
using Loggerdinates.Coordinates.Application.Queries;
using Loggerdinates.Coordinates.Infrastructure.Persistence;
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
    internal class GetCoordinatesByUserIdQueryHandle : IRequestHandler<GetCoordinatesByUserIdQuery, Response<List<CoordinateDto>>>
    {
        private readonly CoordinateDbContext _context;

        public GetCoordinatesByUserIdQueryHandle(CoordinateDbContext context)
        {
            _context = context;
        }

        public async Task<Response<List<CoordinateDto>>> Handle(GetCoordinatesByUserIdQuery request, CancellationToken cancellationToken)
        {
            var coordinates = await _context.Coordinates.Where(x=>x.CreatedBy == request.UserId).ToListAsync();

            if(!coordinates.Any())
            {
                return Response<List<CoordinateDto>>.Success(new List<CoordinateDto>(), statusCode: 200);
            }
            var coordinateDto = ObjectMapper.Mapper.Map<List<CoordinateDto>>(coordinates);

            return Response<List<CoordinateDto>>.Success(coordinateDto, 200);
        }
    }
}
