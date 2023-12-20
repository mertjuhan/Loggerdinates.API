using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loggerdinates.Coordinates.Application.Dtos
{
    public class CoordinateCreateDto
    {
        public string CreatedBy { get; set; }
        public CoordinateInformationDto CoordinateInformation { get; set; }
    }
}
