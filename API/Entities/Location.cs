using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class Location
    {
        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public string Notes { get; set; }
        public ICollection<MasterPart> MasterParts { get; set; }
    }
}