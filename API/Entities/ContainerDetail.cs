using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class ContainerDetail
    {
        public int ContainerDetailId { get; set; }
        public int ContainerId { get; set; }
        public int MasterPartId { get; set; }
        public string PartNumber { get; set; }
        public int ContainerQty { get; set; }
        public string ContainerPalletNo { get; set; }
        public string Notes { get; set; }
        public ICollection<PurchaseOrderLine> PurchaseOrderLines { get; set; }
    }
}