using Loggerdinates.Coordinates.Application.Commands;
using Loggerdinates.Coordinates.Application.Dtos;
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
    public class DeleteCoordinateCommandQueryHandler : IRequestHandler<DeleteCoordinateCommandQuery,Response<CoordinateDeleteDto>>
    {
        private readonly CoordinateDbContext _context;

        public DeleteCoordinateCommandQueryHandler(CoordinateDbContext context)
        {
            _context = context;
        }

        public async Task<Response<CoordinateDeleteDto>> Handle (DeleteCoordinateCommandQuery command, CancellationToken cancellationToken)
        {
            var coordinateItem = await _context.Coordinates.Where(x=>x.Id == command.Id).FirstOrDefaultAsync();

            if(coordinateItem == null)
            {
                return Response<CoordinateDeleteDto>.Fail("This coordinate does not exist in database", 400);
               
            }else
            {
                _context.Remove(coordinateItem);
                await _context.SaveChangesAsync();
                return Response<CoordinateDeleteDto>.Success(200);
            }
        }
    }
}
