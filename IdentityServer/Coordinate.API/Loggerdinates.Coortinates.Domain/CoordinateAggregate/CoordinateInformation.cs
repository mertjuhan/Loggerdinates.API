using Loggerdinates.Coordinates.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loggerdinates.Coortinates.Domain.CoordinateAggregate
{
    public class CoordinateInformation : ValueObject
    {
        public string Name { get; private set; }
        public string Latitude { get; private set; }
        public string Longitude { get; private set; }

        public CoordinateInformation(string name, string latitude, string longitude)
        {
            Name = name;
            Latitude = latitude;
            Longitude = longitude;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
            yield return Latitude;
            yield return Longitude;
        }
    }
}
