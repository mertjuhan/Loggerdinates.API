using Loggerdinates.Coordinates.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loggerdinates.Coortinates.Domain.CoordinateAggregate
{
    public class Coordinate : Entity,IAggregateRoot
    {
        public DateTime CreatedDate { get; private set; } = DateTime.Now;
        public string CreatedBy { get; private set; }

        /// OWNED ENTITY TYPE !!
        public CoordinateInformation CoordinateInformation { get; set; }

        private Coordinate() { }

        public Coordinate(string createdBy, CoordinateInformation coordinateInformation)
        {
            CreatedBy = createdBy;
            CoordinateInformation = coordinateInformation;
        }
    }
}
