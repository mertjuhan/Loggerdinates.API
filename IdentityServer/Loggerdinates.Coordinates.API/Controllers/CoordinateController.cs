using Loggerdinates.Coordinates.Application.Dtos;
using Loggerdinates.Coordinates.Application.Queries;
using Loggerdinates.Shared.ControllerBases;
using Loggerdinates.Shared.Dtos;
using Loggerdinates.Shared.Services;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Loggerdinates.Coordinates.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoordinateController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ISharedIdentityService _sharedIdentityService;

        public CoordinateController(IMediator mediator, ISharedIdentityService sharedIdentityService)
        {
            _mediator = mediator;
            _sharedIdentityService = sharedIdentityService;
        }

        [HttpGet]
        public async Task<Response<List<CoordinateDto>>> GetAllCoordinatesByUserId()
        {
            var response = await _mediator.Send(new GetCoordinatesByUserIdQuery { UserId = _sharedIdentityService.GetUserId });
            return response;
        }
    }
}
