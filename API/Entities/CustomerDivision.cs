using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class CustomerDivision
    {
        public int CustomerDivisionId { get; set; }
        public string CustomerDivisionName { get; set; }
        public string Notes { get; set; }
    }
}