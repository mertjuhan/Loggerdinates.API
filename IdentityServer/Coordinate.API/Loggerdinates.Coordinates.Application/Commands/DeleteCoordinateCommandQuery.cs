﻿using Loggerdinates.Coordinates.Application.Dtos;
using Loggerdinates.Shared.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loggerdinates.Coordinates.Application.Commands
{
    public class DeleteCoordinateCommandQuery : IRequest<Response<CoordinateDeleteDto>>
    {
        public int Id { get; set; }
    }
}
