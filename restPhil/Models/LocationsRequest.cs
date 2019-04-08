using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace restPhil.Models
{
    public class LocationsRequest
    {
        public string ZipCode { get; set; }
        public string lat { get; set; }
        public string lng { get; set; }
        public Int32 range { get; set; }
        public string RangeUnits { get; set; }
    }
}
