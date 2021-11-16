using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class ContainerStatus
    {
        public int ContainerStatusId { get; set; }
        public string ContainerStatusName { get; set; }
        public string Notes { get; set; }
    }
}